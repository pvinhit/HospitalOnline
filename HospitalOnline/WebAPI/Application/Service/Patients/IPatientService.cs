﻿using Application.DTOs;
using Domain.Entity;
using Infrastructure.Common;
using Infrastructure.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Patients
{
	public interface IPatientService
	{
		Task<List<PatientsDto>> GetAllPatients();
		Task<PatientsDto> GetPatientById(int id);
		Task Add(PatientsDto patientsDto);
		Task Update(PatientsDto patientsDto);
		Task Delete(int id);
		Task<PatientImageDto> GetImageById(int imageId);
		Task<int> AddImage(int patientId, PatientImageCreateDto patientImageDto);
		Task<int> UpdateImage(int imageId, ProductImageUpdateDto patientImageUpdateDto);
		Task<int> RemoveImage(int imageId);
		Task<List<PatientsDto>> GetPagingAllPatients(int pageSize, int pageNumber);
		Task<List<PatientsDto>> GetPagedAndSortedAsync(int pageSize, int pageNumber, string orderBy);
		Task<List<PatientsDto>> GetFilteredAndPagedAsync(int pageSize, int pageNumber, string searchTerm);
		Task<PagedList<PatientsDto>> GetPagedSortedAndFilteredAsync(PageParams productParams);
	}
}
