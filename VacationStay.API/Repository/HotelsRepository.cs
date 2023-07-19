using System;
using VacationStay.API.Data;
using VacationStay.API.RepositoryAbstractions;

namespace VacationStay.API.Repository
{
	public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
	{
        public HotelsRepository(VacationStayDbContext context) : base(context)
        {
        }
    }
}

