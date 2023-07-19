using VacationStay.API.DTOs.Hotel;

namespace VacationStay.API.DTOs.Country
{
    public class CountryDto : BaseCountryDto
    {
        public int Id { get; set; }

        public List<HotelDto> Hotels { get; set; }
    }

    
}

