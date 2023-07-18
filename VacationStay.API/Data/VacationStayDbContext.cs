using System;
using Microsoft.EntityFrameworkCore;

namespace VacationStay.API.Data
{
	public class VacationStayDbContext : DbContext
	{
		public VacationStayDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
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
            modelBuilder.Entity<Hotel>().HasData(
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

