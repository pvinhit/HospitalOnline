﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Domain.Entity.Identity
{
	public class AppUser : IdentityUser<Guid>
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public DateTime Dob { get; set; }
	}
}
