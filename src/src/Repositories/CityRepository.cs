using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models;

namespace src.Repositories
{
    public class CityRepository
    {
        private DBContext _dbContext;

        public CityRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<City>> GetCities(string[] includes = null)
        {
            IQueryable<City> query = _dbContext.Set<City>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }
    }
}
