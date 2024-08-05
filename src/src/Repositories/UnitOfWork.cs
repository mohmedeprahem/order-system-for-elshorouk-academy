using System;
using Microsoft.EntityFrameworkCore.Storage;
using src.Data;

namespace src.Repositories
{
    public class UnitOfWork
    {
        private readonly DBContext _dbContext;

        public UserRepository UserRepository { get; private set; }
        public InvoiceRepository InvoiceRepository { get; private set; }
        public CashierRepository CashierRepository { get; private set; }

        private IDbContextTransaction _transaction;

        public UnitOfWork(DBContext dbContext)
        {
            _dbContext = dbContext;
            UserRepository = new UserRepository(_dbContext);
            InvoiceRepository = new InvoiceRepository(_dbContext);
            CashierRepository = new CashierRepository(_dbContext);
            _transaction = null;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackAsync();
                throw; // Re-throw the exception to propagate it
            }
            finally
            {
                _transaction = null;
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
