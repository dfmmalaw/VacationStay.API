using System;
using Microsoft.AspNetCore.Identity;
using VacationStay.API.DTOs.Users;

namespace VacationStay.API.RepositoryAbstractions
{
	public interface IAuthManager
	{
		Task<IEnumerable<IdentityError>> Register(UserDto userDto);
		Task<AuthResponseDto> Login(LoginDto loginDto);
		Task<string> CreateRefreshToken();
		Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
	}
}
