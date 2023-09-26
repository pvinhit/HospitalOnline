using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Role
{
	public interface IRoleService
	{
		Task<List<RoleDto>> GetAll();
	}
}
