using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
	public class PagingDto : PagingRequestBase
	{
		public string Keyword { get; set; }
	}
}
