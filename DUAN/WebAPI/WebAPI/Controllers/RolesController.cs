﻿using Application.Services.Role;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RolesController : ControllerBase
	{
		private readonly IRoleService _roleService;

		public RolesController(IRoleService roleService)
		{
			_roleService = roleService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var roles = await _roleService.GetAll();
			return Ok(roles);
		}
	}
}
