using Application.DTOs;
using Application.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost("authenticate")]
		[AllowAnonymous]
		public async Task<IActionResult> Authenticate([FromBody] LoginDto loginDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = await _userService.Authencate(loginDto);

			if (string.IsNullOrEmpty(result.ResultObj))
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var user = await _userService.GetById(id);
			return Ok(user);
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = await _userService.Register(registerDto);
			if (!result.IsSuccessed)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] UserUpdateDto request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = await _userService.Update(id, request);
			if (!result.IsSuccessed)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var result = await _userService.Delete(id);
			return Ok(result);
		}

		[HttpGet("paging")]
		public async Task<IActionResult> GetAllPaging([FromQuery] PagingDto pagingDto)
		{
			var users = await _userService.GetUsersPaging(pagingDto);
			return Ok(users);
		}

		[HttpPut("{id}/roles")]
		public async Task<IActionResult> RoleAssign(Guid id, [FromBody] RoleAssignDto request)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = await _userService.RoleAssign(id, request);
			if (!result.IsSuccessed)
			{
				return BadRequest(result);
			}
			return Ok(result);
		}

	}
}
