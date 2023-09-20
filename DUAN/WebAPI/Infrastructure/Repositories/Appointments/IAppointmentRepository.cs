using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Appointments
{
	public interface IAppointmentRepository
	{
		Task<List<Appointment>> GetAllAppointments();
	}
}
