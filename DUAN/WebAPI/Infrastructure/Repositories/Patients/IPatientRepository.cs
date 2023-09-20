using Domain.Entity;
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
	}
}
