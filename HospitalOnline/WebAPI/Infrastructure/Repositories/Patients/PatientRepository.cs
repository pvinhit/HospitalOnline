
using Demo.Entities;
using Domain.Entity;
using Infrastructure.Common;
using Infrastructure.EF;
using Infrastructure.Exceptions;
using Infrastructure.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Infrastructure.Repositories.Patients
{
	public class PatientRepository : IPatientRepository
	{
		private readonly DataDbContext _context;

		public PatientRepository(DataDbContext context)
		{
			_context = context;
		}
		public async Task<List<Patient>> GetAllPatients()
		{
			return await _context.Patients.ToListAsync();
		}

		public async Task<Patient> GetPatientById(int id)
		{
			return await _context.Patients.FindAsync(id);
		}
		public async Task Add(Patient patient)
		{
			_context.Patients.Add(patient);
			await _context.SaveChangesAsync();
		}

		public async Task Update(Patient patient)
		{
			_context.Patients.Update(patient);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var patient = await _context.Patients.FindAsync(id);
			if (patient != null)
			{
				_context.Patients.Remove(patient);
				await _context.SaveChangesAsync();
			}
		}
		public async Task<PatientImage> GetImageById(int imageId)
		{
			return await _context.PatientImages.FindAsync(imageId);
		}

		public async Task<int> AddPatientImage(PatientImage patientImage)
		{
			_context.PatientImages.Add(patientImage);
			return await _context.SaveChangesAsync();
		}

		public async Task<int> UpdateImage(int imageId, PatientImage patientImageage)
		{
			try
			{
				var updateImage = await _context.PatientImages.FindAsync(imageId);
				if (updateImage != null)
				{
					updateImage.ImagePath = patientImageage.ImagePath;
					updateImage.Caption = patientImageage.Caption;
					updateImage.IsDefault = patientImageage.IsDefault;
					updateImage.DateCreated = patientImageage.DateCreated;
					updateImage.SortOrder = patientImageage.SortOrder;
					updateImage.FileSize = patientImageage.FileSize;
					updateImage.patientId = patientImageage.patientId;

					await _context.SaveChangesAsync(); 
					return 1; 
				}
				return 0; 
			}
			catch (AmbiguousMatchException)
			{
				return -1; 
			}
		}

		public async Task<int> RemoveProductImage(int imageId)
		{
			try
			{
				var patientImage = await _context.PatientImages.FindAsync(imageId);
				if (patientImage == null)
				{
					throw new CustomException($"Cannot find an image with id {imageId}");
				}
				_context.PatientImages.Remove(patientImage);
				return await _context.SaveChangesAsync();
			} 
			catch (AmbiguousMatchException)
			{
				return -1;
			}
		}

		public async Task<List<Patient>> GetPagingAllPatients(int pageSize, int pageNumber)
		{
			var allPatients = _context.Patients
							 .AsQueryable();
			var pagedPatients = await allPatients
									.Skip((pageNumber - 1) * pageSize)
									.Take(pageSize)
									.ToListAsync();
			return pagedPatients;
		}

		public async Task<List<Patient>> GetPagedAndSortedAsync(int pageSize, int pageNumber, string orderBy)
		{
			var query = _context.Patients.AsQueryable();

			// Áp dụng sắp xếp
			if (!string.IsNullOrEmpty(orderBy))
			{
				switch (orderBy.ToLower())
				{
					case "name":
						query = query.OrderBy(Patients => Patients.FirstName);
						break;
					case "date":
						query = query.OrderBy(Patients => Patients.DateOfBirth);
						break;
					// Thêm các trường sắp xếp khác ở đây nếu cần
					default:
						query = query.OrderBy(Patients => Patients.Id); // Sắp xếp mặc định theo Id
						break;
				}
			}
			return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
		}

		public async Task<List<Patient>> GetPagedAndFilteredAsync(int pageSize, int pageNumber, string searchTerm)
		{
			var query = _context.Patients.AsQueryable();

			// Áp dụng lọc
			if (!string.IsNullOrEmpty(searchTerm))
			{
				query = query.Where(Patients => Patients.FirstName.Contains(searchTerm));
				query = query.Where(Patients => Patients.LastName.Contains(searchTerm));
				// Thêm các điều kiện lọc khác ở đây nếu cần
			}

			return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
		}

		public async Task<PagedList<Patient>> GetPagedSortedAndFilteredAsync(PageParams patientParams)
		{

			var query = _context.Patients.AsQueryable();

			// Áp dụng sắp xếp dựa trên productParams.OrderBy
			if (patientParams.OrderBy == "Gender")
			{
				query = query.OrderBy(p => p.Gender);
			}
			else if (patientParams.OrderBy == "Name")
			{
				query = query.OrderBy(p => p.FirstName);
			}
			// Thêm các điều kiện sắp xếp khác tùy theo nhu cầu
			return await PagedList<Patient>.ToPagedList(query, patientParams.PageNumber, patientParams.PageSize);
		}
	}
}
