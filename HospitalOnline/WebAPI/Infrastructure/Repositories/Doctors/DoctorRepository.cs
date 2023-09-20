using Demo.Entities;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Doctors
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DataDbContext _context;

        public DoctorRepository(DataDbContext context)
        {
            _context = context;
        }
        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }
        public async Task AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
