using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VacationStay.API.Data.Configurations
{
	public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
	{
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Sandals South Africa",
                    Address = "Johannesburg",
                    CountryId = 1,
                    Rating = 4.8
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Sandals Ontario",
                    Address = "Toronto",
                    CountryId = 2,
                    Rating = 4.3
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Sandals Nevada",
                    Address = "Las Vegas",
                    CountryId = 3,
                    Rating = 4.9
                },
                new Hotel
                {
                    Id = 4,
                    Name = "Sandals British Colombia",
                    Address = "Vancouver",
                    CountryId = 2,
                    Rating = 4.5
                }
            );
        }
    }
}

