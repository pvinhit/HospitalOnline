using Application.DTOs;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Appointments
{
	public interface IAppointmentService
	{
		Task<List<AppointmentDto>> GetAllAppointments();
	}
}
