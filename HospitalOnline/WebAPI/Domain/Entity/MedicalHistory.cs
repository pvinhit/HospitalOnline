using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
	public class MedicalHistory
	{
		public int Id { get; set; }
		public int patientId { get; set; }
		public int doctorId { get; set; }
		public DateTime VisitDate { get; set; }
		public string Diagnosis { get; set; }
		public string Prescription { get; set; }
		public Patient Patient { get; set; }
	}
}
