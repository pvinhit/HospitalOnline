using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
	public class PatientsDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Gender { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public string NumberBHYT { get; set; }
		public List<AppointmentDto> Appointments { get; set; }
	}
}
