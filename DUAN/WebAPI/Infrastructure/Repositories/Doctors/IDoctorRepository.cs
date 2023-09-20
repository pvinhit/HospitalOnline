using Demo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Doctors
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAllDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task AddDoctor(Doctor doctor);
        Task UpdateDoctor(Doctor doctor);
        Task DeleteDoctor(int id);
    }
}
