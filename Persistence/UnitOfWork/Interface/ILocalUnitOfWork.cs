using DatabaseSync.Persistence.Repository.Interface.Local;

namespace DatabaseSync.Persistence.UnitOfWork.Interface
{
    public interface ILocalUnitOfWork : IUnitOfWork
    {
        // Repositories
        ILocalCustomerRepository Customers { get; }
        ILocalLocationRepository Locations { get; }
        ILocalSyncLogRepository SyncLogs { get; }
    }
}
