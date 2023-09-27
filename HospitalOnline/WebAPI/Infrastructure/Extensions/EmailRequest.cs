using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Extensions
{
	public class EmailRequest
	{
		public string ToEmail { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
	}
}
