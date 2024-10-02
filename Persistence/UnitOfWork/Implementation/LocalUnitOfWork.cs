using DatabaseSync.Persistence.Context;
using DatabaseSync.Persistence.Repository.Implementation.Local;
using DatabaseSync.Persistence.Repository.Interface.Local;
using DatabaseSync.Persistence.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace DatabaseSync.Persistence.UnitOfWork.Implementation
{
    public class LocalUnitOfWork : ILocalUnitOfWork
    {
        private readonly LocalDbContext _context;

        private bool _disposed = false;

        //-----------[ Add repositories here ]----------
        public ILocalCustomerRepository Customers { get; }
        public ILocalLocationRepository Locations { get; }
        public ILocalSyncLogRepository SyncLogs { get; }
        //----------------------------------------------

        public LocalUnitOfWork(LocalDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            //----------[ Initialize repositories here ]----------
            Customers = new LocalCustomerRepository(_context);
            Locations = new LocalLocationRepository(_context);
            SyncLogs = new LocalSyncLogRepository(_context);
            //----------------------------------------------------
        }

        public int Complete() => _context.SaveChanges();

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public IDbContextTransaction BeginTransaction() => _context.Database.BeginTransaction();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}