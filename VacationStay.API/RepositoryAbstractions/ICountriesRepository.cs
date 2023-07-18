using VacationStay.API.Data;

namespace VacationStay.API.RepositoryAbstractions
{
    public interface ICountriesRepository : IGenericRepository<Country>
	{
		Task<Country> GetDetails(int id);
	}
}

