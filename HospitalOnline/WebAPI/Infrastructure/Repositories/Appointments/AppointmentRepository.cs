using Domain.Entity;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Appointments
{
	public class AppointmentRepository : IAppointmentRepository
	{
		private readonly DataDbContext _context;

		public AppointmentRepository(DataDbContext context)
        {
			_context = context;
        }
        public async Task<List<Appointment>> GetAllAppointments()
		{
			return await _context.Appointments.ToListAsync();
		}
	}
}
