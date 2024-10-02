using DatabaseSync.Persistence.Repository.Interface.Server;

namespace DatabaseSync.Persistence.UnitOfWork.Interface
{
    public interface IServerUnitOfWork : IUnitOfWork
    {
        // Repositories
        IServerCustomerRepository Customers { get; }
        IServerLocationRepository Locations { get; }
    }
}
