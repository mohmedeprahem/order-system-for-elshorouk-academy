using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models;

namespace src.Repositories
{
    public class CashierRepository
    {
        private readonly DBContext _dbContext;

        public CashierRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cashier>> getAllCashiers(string[] includes = null)
        {
            IQueryable<Cashier> query = _dbContext.Set<Cashier>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public async Task AddCashier(Cashier cashier)
        {
            await _dbContext.Cashiers.AddAsync(cashier);
        }

        public async Task<Cashier> GetCashierById(int id, string[] includes = null)
        {
            IQueryable<Cashier> query = _dbContext.Set<Cashier>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteCashier(Cashier cashier)
        {
            _dbContext.Cashiers.Remove(cashier);
        }
    }
}
