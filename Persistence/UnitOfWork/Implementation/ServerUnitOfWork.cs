using DatabaseSync.Persistence.Context;
using DatabaseSync.Persistence.Repository.Implementation.Server;
using DatabaseSync.Persistence.Repository.Interface.Server;
using DatabaseSync.Persistence.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace DatabaseSync.Persistence.UnitOfWork.Implementation
{
    public class ServerUnitOfWork : IServerUnitOfWork
    {
        private readonly ServerDbContext _context;

        private bool _disposed = false;

        //-----------[ Add repositories here ]----------
        public IServerCustomerRepository Customers { get; }
        public IServerLocationRepository Locations { get; }
        //----------------------------------------------

        public ServerUnitOfWork(ServerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            //----------[ Initialize repositories here ]----------
            Customers = new ServerCustomerRepository(_context);
            Locations = new ServerLocationRepository(_context);
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
