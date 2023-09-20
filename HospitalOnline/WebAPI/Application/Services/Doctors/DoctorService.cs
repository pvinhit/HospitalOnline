using AutoMapper;
using Demo.DTOs;
using Demo.Entities;
using Infrastructure.Repositories.Doctors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Doctors
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        public async Task<List<DoctorDto>> GetAllDoctor()
        {
            var doctors = await _doctorRepository.GetAllDoctors();
            return _mapper.Map<List<DoctorDto>>(doctors);
        }

        public async Task<DoctorDto> GetDoctorById(int id)
        {
            var doctor = await _doctorRepository.GetDoctorById(id);
            if (doctor == null)
            {
                return null;
            }
            return _mapper.Map<DoctorDto>(doctor);
        }
        public async Task AddDoctor(DoctorDto doctorDto)
        {
            var addDoctor = _mapper.Map<Doctor>(doctorDto);
            await _doctorRepository.AddDoctor(addDoctor);
        }
        public async Task UpdateDoctor(DoctorDto doctorDto)
        {
            var updateDoctor = _mapper.Map<Doctor>(doctorDto);
            await _doctorRepository.UpdateDoctor(updateDoctor);
        }
        public async Task DeleteDoctor(int id)
        {
            await _doctorRepository.DeleteDoctor(id);
        }
    }
}
