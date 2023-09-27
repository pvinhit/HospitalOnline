using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Filters
{
	public class PageParams : PaginationParams
	{
		public string OrderBy { get; set; }
		public string SearchTerm { get; set; }
		public string Types { get; set; }
		public string Brands { get; set; }
	}
}
