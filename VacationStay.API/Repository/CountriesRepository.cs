using System;
using Microsoft.EntityFrameworkCore;
using VacationStay.API.Data;
using VacationStay.API.RepositoryAbstractions;

namespace VacationStay.API.Repository
{
	public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
	{
        private readonly VacationStayDbContext _context;

        public CountriesRepository(VacationStayDbContext context) : base(context)
		{
            _context = context;
        }

        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries.Include(q => q.Hotels)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}

