using Application.DTOs;
using Application.Services.Common;
using AutoMapper;
using Demo.DTOs;
using Demo.Entities;
using Domain.Entity;
using Infrastructure.Common;
using Infrastructure.Exceptions;
using Infrastructure.Filters;
using Infrastructure.Repositories.Patients;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Patients
{
	public class PatientService : IPatientService
	{
		private readonly IPatientRepository _patientRepository;
		private readonly IMapper _mapper;
		private readonly IStorageService _storageService;
		private const string PATIENT_CONTENT_FOLDER_NAME = "patient-content";

		public PatientService(IPatientRepository patientRepository, IMapper mapper, IStorageService storageService)
        {
			_patientRepository = patientRepository;
			_mapper = mapper;
			_storageService = storageService;
		}
		public async Task<List<PatientsDto>> GetAllPatients()
		{
			var patients = await _patientRepository.GetAllPatients();
			return _mapper.Map<List<PatientsDto>>(patients);
		}

		public async Task<PatientsDto> GetPatientById(int id)
		{
			var patient = await _patientRepository.GetPatientById(id);
			return _mapper.Map<PatientsDto>(patient);
		}
		public async Task Add(PatientsDto patientsDto)
		{
			var patientAdd = _mapper.Map<Patient>(patientsDto);
			await _patientRepository.Add(patientAdd);
		}
		public async Task Update(PatientsDto patientsDto)
		{
			var patientUpdate = _mapper.Map<Patient>(patientsDto);
			await _patientRepository.Update(patientUpdate);
		}

		public async Task Delete(int id)
		{
			await _patientRepository.Delete(id);	
		}

		public async Task<PatientImageDto> GetImageById(int imageId)
		{
			var image = await _patientRepository.GetImageById(imageId);
			if (image == null)
			{
				throw new CustomException($"Cannot find an image with id {imageId}");
			}

			var viewModel = new PatientImageDto()
			{
				Caption = image.Caption,
				DateCreated = image.DateCreated,
				FileSize = image.FileSize,
				Id = image.Id,
				ImagePath = image.ImagePath,
				IsDefault = image.IsDefault,
				patientId = image.patientId,
				SortOrder = image.SortOrder
			};
			return viewModel;
		}

		public async Task<int> AddImage(int patientId, PatientImageCreateDto patientImageDto)
		{
			var productImage = _mapper.Map<PatientImage>(patientImageDto);
			productImage.patientId = patientId;
			productImage.DateCreated = DateTime.Now;
			if (patientImageDto.ImageFile != null)
			{
				productImage.ImagePath = await this.SaveFile(patientImageDto.ImageFile);
				productImage.FileSize = patientImageDto.ImageFile.Length;
				productImage.SortOrder = patientImageDto.SortOrder;
			}
			int imageId = await _patientRepository.AddPatientImage(productImage);
			return imageId;
		}
		private async Task<string> SaveFile(IFormFile file)
		{
			var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
			var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
			await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
			return "/" + PATIENT_CONTENT_FOLDER_NAME + "/" + fileName;
		}

		public async Task<int> UpdateImage(int imageId, ProductImageUpdateDto patientImageUpdateDto)
		{
			var patientImage = await _patientRepository.GetImageById(imageId);
			if (patientImage == null)
			{
				throw new CustomException($"Cannot find an image with id {imageId}");
			}

			_mapper.Map(patientImageUpdateDto, patientImage);
			if (patientImageUpdateDto.ImageFile != null)
			{
				patientImage.ImagePath = await this.SaveFile(patientImageUpdateDto.ImageFile);
				patientImage.FileSize = patientImageUpdateDto.ImageFile.Length;
			}
			return await _patientRepository.UpdateImage(imageId, patientImage);
		}

		public async Task<int> RemoveImage(int imageId)
		{
			return await _patientRepository.RemoveProductImage(imageId);
		}

		public async Task<List<PatientsDto>> GetPagingAllPatients(int pageSize, int pageNumber)
		{
			var patients = await _patientRepository.GetPagingAllPatients(pageSize, pageNumber );
			return _mapper.Map<List<PatientsDto>>(patients);
		}

		public async Task<List<PatientsDto>> GetPagedAndSortedAsync(int pageSize, int pageNumber, string orderBy)
		{
			var patients = await _patientRepository.GetPagedAndSortedAsync(pageSize, pageNumber, orderBy);
			return _mapper.Map<List<PatientsDto>>(patients);
		}

		public async Task<List<PatientsDto>> GetFilteredAndPagedAsync(int pageSize, int pageNumber, string searchTerm)
		{
			var patients = await _patientRepository.GetPagedAndFilteredAsync(pageSize, pageNumber, searchTerm);
			return _mapper.Map<List<PatientsDto>>(patients);
			
		}

		public async Task<PagedList<PatientsDto>> GetPagedSortedAndFilteredAsync(PageParams productParams)
		{
			var patients = await _patientRepository.GetPagedSortedAndFilteredAsync(productParams);
			return _mapper.Map<PagedList<PatientsDto>>(patients);
		}
	}
}
