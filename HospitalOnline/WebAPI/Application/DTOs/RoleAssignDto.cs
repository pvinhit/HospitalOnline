using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
	public class RoleAssignDto
	{
		public Guid Id { get; set; }
		public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
	}
}
