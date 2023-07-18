using System;
using System.ComponentModel.DataAnnotations;

namespace VacationStay.API.DTOs.Country
{
	public abstract class BaseCountryDto
	{
		[Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}

