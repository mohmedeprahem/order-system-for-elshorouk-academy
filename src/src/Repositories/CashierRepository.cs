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

        public async Task<List<Cashier>> getAllCashiers()
        {
            return await _dbContext.Cashiers.ToListAsync();
        }
    }
}
