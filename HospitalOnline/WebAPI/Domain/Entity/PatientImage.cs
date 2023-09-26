using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
	public class PatientImage
	{
		public int Id { get; set; }
		public string ImagePath { get; set; }
		public string Caption { get; set; }
		public bool IsDefault { get; set; }
		public DateTime DateCreated { get; set; }
		public int SortOrder { get; set; }
		public long FileSize { get; set; }
		public int patientId { get; set; }
		public Patient Patient { get; set; }
	}
}
