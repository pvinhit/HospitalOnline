using Demo.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Doctors
{
    public interface IDoctorService
    {
        Task<List<DoctorDto>> GetAllDoctor();
        Task<DoctorDto> GetDoctorById(int id);
        Task AddDoctor(DoctorDto doctorDto);
        Task UpdateDoctor(DoctorDto doctorDto);
        Task DeleteDoctor(int id);
    }
}
