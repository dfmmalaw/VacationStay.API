using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VacationStay.API.Data.Configurations
{
	public class CountryConfiguration : IEntityTypeConfiguration<Country>
	{
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                new Country
                {
                    Id = 1,
                    Name = "South Africa",
                    ShortName = "SA"
                },
                new Country
                {
                    Id = 2,
                    Name = "Canada",
                    ShortName = "CA"
                },
                new Country
                {
                    Id = 3,
                    Name = "United States",
                    ShortName = "US"
                }
            );
        }
    }
}

