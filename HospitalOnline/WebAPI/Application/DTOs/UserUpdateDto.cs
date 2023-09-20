using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace Application.DTOs
{
	public class UserUpdateDto
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime Dob { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
	}
}
