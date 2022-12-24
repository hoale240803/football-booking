using FootballBooking.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace FootballBooking.Infrastructure.Interface
{
    public class DatabaseTransaction : IDatabaseTransaction
    {
        private readonly IDbContextTransaction _transaction;

        public DatabaseTransaction(FootballBookingDbContext context)
        {
            _transaction = context.Database.BeginTransaction();
       
        }


        public void Commit()
        {
            _transaction.Commit();
        }

        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Cleanup
            if (disposing)
            {
                // free managed resources
                _transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }
    }
}