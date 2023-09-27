using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Filters
{
	public class Page
	{
		public int CurrentPage { get; set; }
		public int TotalPages { get; set; }
		public int PageSize { get; set; }
		public int TotalCount { get; set; }
	}
}
