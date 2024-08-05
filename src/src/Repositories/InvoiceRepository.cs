using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models;

namespace src.Repositories
{
    public class InvoiceRepository
    {
        private readonly DBContext _dbContext;

        public InvoiceRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<InvoiceHeader>> GetAllInvoices(
            int pageNumber = 1,
            int pageSize = 10,
            string[] includes = null
        )
        {
            IQueryable<InvoiceHeader> query = _dbContext.Set<InvoiceHeader>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
