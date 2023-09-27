using Application.DTOs;
using Domain.Entity.Identity;
using Infrastructure.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User
{
	public class UserService : IUserService
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;
		private readonly IConfiguration _configuration;
	
		public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IConfiguration configuration)
        {
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_configuration = configuration;
		}
		public async Task<ApiResult<string>> Authencate(LoginDto loginDto)
		{
			var user = await _userManager.FindByNameAsync(loginDto.UserName);
			if (user == null)
			{
				return new ApiErrorResult<string>("Tài khoản không tồn tại");
			}
			var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, loginDto.RememberMe, true);
			if (!result.Succeeded)
			{
				return new ApiErrorResult<string>("Đăng nhập không đúng");
			}
			var roles = await _userManager.GetRolesAsync(user);
			var claims = new[]
			{
				new Claim(ClaimTypes.Email,user.Email),
				new Claim(ClaimTypes.GivenName,user.FirstName),
				new Claim(ClaimTypes.Role, string.Join(";",roles)),
				new Claim(ClaimTypes.Name, loginDto.UserName)
			};
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(_configuration["Tokens:Issuer"],
				_configuration["Tokens:Issuer"],
				claims,
				expires: DateTime.Now.AddHours(3),
				signingCredentials: creds);

			return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
		}
		public async Task<ApiResult<UserDto>> GetById(Guid id)
		{
			var user = await _userManager.FindByIdAsync(id.ToString());
			if (user == null)
			{
				return new ApiErrorResult<UserDto>("User không tồn tại");
			}
			var roles = await _userManager.GetRolesAsync(user);
			var userDto = new UserDto()
			{
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				FirstName = user.FirstName,
				Dob = user.Dob,
				Id = user.Id,
				LastName = user.LastName,
				UserName = user.UserName,
				Roles = roles
			};
			return new ApiSuccessResult<UserDto>(userDto);
		}

		public async Task<ApiResult<bool>> Register(RegisterDto registerDto)
		{
			var user = await _userManager.FindByNameAsync(registerDto.UserName);
			if (user != null)
			{
				return new ApiErrorResult<bool>("Tài khoản đã tồn tại");
			}
			if (await _userManager.FindByEmailAsync(registerDto.Email) != null)
			{
				return new ApiErrorResult<bool>("Emai đã tồn tại");
			}

			user = new AppUser()
			{
				Dob = registerDto.Dob,
				Email = registerDto.Email,
				FirstName = registerDto.FirstName,
				LastName = registerDto.LastName,
				UserName = registerDto.UserName,
				PhoneNumber = registerDto.PhoneNumber
			};
			var result = await _userManager.CreateAsync(user, registerDto.Password);
			if (result.Succeeded)
			{
				return new ApiSuccessResult<bool>();
			}
			return new ApiErrorResult<bool>("Đăng ký không thành công");
		}

		public async Task<ApiResult<bool>> Update(Guid id, UserUpdateDto userUpdateDto)
		{
			if (await _userManager.Users.AnyAsync(x => x.Email == userUpdateDto.Email && x.Id != id))
			{
				return new ApiErrorResult<bool>("Emai đã tồn tại");
			}
			var user = await _userManager.FindByIdAsync(id.ToString());
			user.Dob = userUpdateDto.Dob;
			user.Email = userUpdateDto.Email;
			user.FirstName = userUpdateDto.FirstName;
			user.LastName = userUpdateDto.LastName;
			user.PhoneNumber = userUpdateDto.PhoneNumber;

			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return new ApiSuccessResult<bool>();
			}
			return new ApiErrorResult<bool>("Cập nhật không thành công");
		}
		public async Task<ApiResult<bool>> Delete(Guid id)
		{
			var user = await _userManager.FindByIdAsync(id.ToString());
			if (user == null)
			{
				return new ApiErrorResult<bool>("User không tồn tại");
			}
			var reult = await _userManager.DeleteAsync(user);
			if (reult.Succeeded)
				return new ApiSuccessResult<bool>();

			return new ApiErrorResult<bool>("Xóa không thành công");
		}

		//public async Task<ApiResult<PagedResult<UserDto>>> GetUsersPaging(PagingDto pagingDto)
		//{

			//2.filter
			//var query = _userManager.Users;
			//if (!string.IsNullOrEmpty(pagingDto.Keyword))
			//{
			//	query = query.Where(x => x.UserName.Contains(pagingDto.Keyword)
			//	 || x.PhoneNumber.Contains(pagingDto.Keyword));
			//}

			//3.Paging
			//int totalRow = await query.CountAsync();

			//var data = await query.Skip((pagingDto.PageIndex - 1) * pagingDto.PageSize)
			//	.Take(pagingDto.PageSize)
			//	.Select(x => new UserDto()
			//	{
			//		Email = x.Email,
			//		PhoneNumber = x.PhoneNumber,
			//		UserName = x.UserName,
			//		FirstName = x.FirstName,
			//		Id = x.Id,
			//		LastName = x.LastName
			//	}).ToListAsync();

			//4.Select and projection
			//var pagedResult = new PagedResult<UserDto>()
			//{
			//	TotalRecords = totalRow,
			//	PageIndex = pagingDto.PageIndex,
			//	PageSize = pagingDto.PageSize,
			//	Items = data
			//};
			//return new ApiSuccessResult<PagedResult<UserDto>>(pagedResult);
		//}

		public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignDto request)
		{
			var user = await _userManager.FindByIdAsync(id.ToString());
			if (user == null)
			{
				return new ApiErrorResult<bool>("Tài khoản không tồn tại");
			}
			var removedRoles = request.Roles.Where(x => x.Selected == false).Select(x => x.Name).ToList();
			foreach (var roleName in removedRoles)
			{
				if (await _userManager.IsInRoleAsync(user, roleName) == true)
				{
					await _userManager.RemoveFromRoleAsync(user, roleName);
				}
			}
			await _userManager.RemoveFromRolesAsync(user, removedRoles);

			var addedRoles = request.Roles.Where(x => x.Selected).Select(x => x.Name).ToList();
			foreach (var roleName in addedRoles)
			{
				if (await _userManager.IsInRoleAsync(user, roleName) == false)
				{
					await _userManager.AddToRoleAsync(user, roleName);
				}
			}
			return new ApiSuccessResult<bool>();
		}
	}
}
