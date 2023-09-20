using Demo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
	public class Appointment
	{
		public int Id { get; set; }
		public DateTime AppointmentDate { get; set; }
		public DateTime AppointmentTime { get; set; }
		public string Status { get; set; }
		public int patientId { get; set; }
		public Patient Patient { get; set; }
		public int doctorId { get; set; }
		public Doctor Doctor { get; set; }
	}
}
