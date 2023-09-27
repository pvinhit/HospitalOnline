using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Filters
{
	public class PaginationParams
	{
		private const int maxPageSize = 9;
		public int PageNumber { get; set; } = 1;
		private int _pageSize = 3;

		public int PageSize
		{
			get => _pageSize;
			set => _pageSize = value > maxPageSize ? maxPageSize : value;
		}
	}
}
