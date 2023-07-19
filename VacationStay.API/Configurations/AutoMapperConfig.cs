using System;
using AutoMapper;
using VacationStay.API.Data;
using VacationStay.API.DTOs.Country;
using VacationStay.API.DTOs.Hotel;

namespace VacationStay.API.Configurations
{
	public class AutoMapperConfig : Profile 
	{
		public AutoMapperConfig()
		{
			CreateMap<Country, CreateCountryDto>().ReverseMap();
			CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
			CreateMap<Country, UpdateCountryDto>().ReverseMap();

            CreateMap<Hotel, HotelDto>().ReverseMap();
        }
	}
}

