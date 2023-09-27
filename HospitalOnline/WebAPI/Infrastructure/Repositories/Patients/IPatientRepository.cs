using Demo.Entities;
using Domain.Entity;
using Infrastructure.Common;
using Infrastructure.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Patients
{
	public interface IPatientRepository
	{
		Task<List<Patient>> GetAllPatients();
		Task<Patient> GetPatientById(int id);
		Task Add(Patient patient);
		Task Update(Patient patient);
		Task Delete(int id);
		Task<PatientImage> GetImageById(int imageId);
		Task<int> AddPatientImage(PatientImage patientImage);
		Task<int> UpdateImage(int imageId, PatientImage patientImage);
		Task<int> RemoveProductImage(int imageId);
		Task<List<Patient>> GetPagingAllPatients(int pageNumber, int pageSize);
		Task<List<Patient>> GetPagedAndSortedAsync(int pageSize, int pageNumber, string orderBy);
		Task<List<Patient>> GetPagedAndFilteredAsync(int pageSize, int pageNumber, string searchTerm);
		Task<PagedList<Patient>> GetPagedSortedAndFilteredAsync(PageParams patientParams);
	}
}
