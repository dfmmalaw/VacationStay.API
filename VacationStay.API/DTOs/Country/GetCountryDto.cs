using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationStay.API.DTOs.Country
{
    public class GetCountryDto : BaseCountryDto
	{
        public int Id { get; set; }
    }
}

