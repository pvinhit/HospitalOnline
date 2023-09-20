using Demo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
	public class Patient
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Gender { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public string NumberBHYT { get; set; }
		public int doctorId { get; set; }
		public Doctor Doctor { get; set; }
		public List<Appointment> Appointments { get; set; }
	}
}
