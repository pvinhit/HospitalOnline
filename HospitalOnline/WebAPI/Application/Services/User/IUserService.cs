using Application.DTOs;
using Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User
{
	public interface IUserService 
	{
		Task<ApiResult<UserDto>> GetById(Guid id);
		Task<ApiResult<string>> Authencate(LoginDto loginDto);
		Task<ApiResult<bool>> Register(RegisterDto registerDto);
		Task<ApiResult<bool>> Update(Guid id, UserUpdateDto userUpdateDto);
		Task<ApiResult<bool>> Delete(Guid id);
		Task<ApiResult<PagedResult<UserDto>>> GetUsersPaging(PagingDto pagingDto);
		Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignDto request);
	}
}
