using System;
using System.ComponentModel.DataAnnotations;

namespace VacationStay.API.DTOs.Users
{
    public class UserDto : LoginDto
	{
		[Required]
		public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
	}
}

