
using Domain.Entity;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
