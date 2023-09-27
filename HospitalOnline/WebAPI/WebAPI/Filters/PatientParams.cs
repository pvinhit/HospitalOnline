using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Filters
{
	public class PatientParams : PaginationParams
	{
		public string OrderBy { get; set; }
		public string SearchTerm { get; set; }
		public string Types { get; set; }
		public string Brands { get; set; }
	}
}
