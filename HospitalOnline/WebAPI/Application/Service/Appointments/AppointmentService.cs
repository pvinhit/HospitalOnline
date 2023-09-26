using Application.DTOs;
using AutoMapper;
using Domain.Entity;
using Infrastructure.Repositories.Appointments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Appointments
{
	public class AppointmentService : IAppointmentService
	{
		private readonly IAppointmentRepository _appointmentRepository;
		private readonly IMapper _mapper;

		public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
			_appointmentRepository = appointmentRepository;
			_mapper = mapper;
        }
        public async Task<List<AppointmentDto>> GetAllAppointments()
		{
			var appointments = await _appointmentRepository.GetAllAppointments();
			return _mapper.Map<List<AppointmentDto>>(appointments);
		}
	}
}

