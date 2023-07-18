using System;
using Microsoft.EntityFrameworkCore;
using VacationStay.API.Data;
using VacationStay.API.RepositoryAbstractions;

namespace VacationStay.API.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
        private readonly VacationStayDbContext _context;

        public GenericRepository(VacationStayDbContext context)
        {
            this._context = context;
        }

		public GenericRepository()
		{
		}

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChangesAsync();
            
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }

            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

