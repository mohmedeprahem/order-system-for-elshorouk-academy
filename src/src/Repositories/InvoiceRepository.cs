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

        public async Task<InvoiceHeader> GetInvoiceById(long id, string[] includes = null)
        {
            IQueryable<InvoiceHeader> query = _dbContext.Set<InvoiceHeader>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<InvoiceHeader> AddInvoice(InvoiceHeader invoice)
        {
            await _dbContext.InvoiceHeaders.AddAsync(invoice);
            return invoice;
        }

        public async Task<InvoiceDetail> AddInvoiceDetail(InvoiceDetail invoiceDetails)
        {
            await _dbContext.InvoiceDetails.AddAsync(invoiceDetails);
            return invoiceDetails;
        }

        public InvoiceHeader UpdateInvoice(InvoiceHeader invoice)
        {
            _dbContext.InvoiceHeaders.Update(invoice);
            return invoice;
        }

        public async Task DeleteInvoice(InvoiceHeader invoice)
        {
            var invoiceDetails = await this.GetAllInvoiceDetails(
                x => x.InvoiceHeaderId == invoice.Id
            );

            foreach (var invoiceDetail in invoiceDetails)
            {
                _dbContext.InvoiceDetails.Remove(invoiceDetail);
            }
            await _dbContext.SaveChangesAsync();

            _dbContext.InvoiceHeaders.Remove(invoice);
        }

        public async Task<List<InvoiceDetail>> GetAllInvoiceDetails(
            Func<InvoiceDetail, bool> predicate = null,
            string[] includes = null
        )
        {
            IQueryable<InvoiceDetail> query = _dbContext.Set<InvoiceDetail>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (predicate != null)
            {
                query = query.Where(predicate).AsQueryable();
            }

            return query.AsEnumerable().ToList();
        }

        public async Task DeleteInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            _dbContext.InvoiceDetails.Remove(invoiceDetail);
        }
    }
}
