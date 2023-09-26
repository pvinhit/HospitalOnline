using Application.DTOs;
using AutoMapper;
using Demo.DTOs;
using Demo.Entities;
using Domain.Entity;

namespace Demo.Helper
{
	public class MapperDto : Profile
	{
		public MapperDto()
		{
			CreateMap<Doctor, DoctorDto>(); // Ánh xạ từ Doctor sang DoctorDto
			CreateMap<DoctorDto, Doctor>(); // Ánh xạ từ DoctorDto sang Doctor (nếu cần)

			CreateMap<Patient, PatientsDto>(); 
			CreateMap<PatientsDto, Patient>();

			CreateMap<Appointment, AppointmentDto>();
			CreateMap<AppointmentDto, Appointment>();

			CreateMap<PatientImage, PatientImageCreateDto>();
			CreateMap<PatientImageCreateDto, PatientImage>();

			CreateMap<PatientImage, ProductImageUpdateDto>();
			CreateMap<ProductImageUpdateDto, PatientImage>();

			
		}
	}
}
