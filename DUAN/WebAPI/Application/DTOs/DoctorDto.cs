using Application.DTOs;
using System.Collections.Generic;

namespace Demo.DTOs
{
	public class DoctorDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Specialty { get; set; }
		public string Phone { get; set; }
		public List<PatientsDto> Patients { get; set; }
		public List<AppointmentDto> Appointments { get; set; }
	}
}
