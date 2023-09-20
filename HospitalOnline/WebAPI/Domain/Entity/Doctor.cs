using Domain.Entity;
using System.Collections.Generic;

namespace Demo.Entities
{
	public class Doctor
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Specialty { get; set; }
		public string Phone { get; set; }
		public List<Patient> Patients { get; set; }
		public List<Appointment> Appointments { get; set; }
	}
}
