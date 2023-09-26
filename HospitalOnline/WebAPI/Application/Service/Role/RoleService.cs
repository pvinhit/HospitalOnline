using Application.DTOs;
using Domain.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Role
{
	public class RoleService : IRoleService
	{
		private readonly RoleManager<AppRole> _roleManager;

		public RoleService(RoleManager<AppRole> roleManager)
        {
			_roleManager = roleManager;
		}
		public async Task<List<RoleDto>> GetAll()
		{
			var roles = await _roleManager.Roles
				.Select(x => new RoleDto()
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description
				}).ToListAsync();

			return roles;
		}
	}
}
