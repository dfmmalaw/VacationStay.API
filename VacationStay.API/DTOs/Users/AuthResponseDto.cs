﻿using System;
namespace VacationStay.API.DTOs.Users
{
	public class AuthResponseDto
	{
		public string UserId { get; set; }
		public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}

