using DatabaseSync.Persistence.Context;
using DatabaseSync.Persistence.Entities;
using DatabaseSync.Persistence.Repository.Interface.Local;

namespace DatabaseSync.Persistence.Repository.Implementation.Local
{
    public class LocalCustomerRepository : LocalRepository<Customer>, ILocalCustomerRepository
    {
        public LocalCustomerRepository(LocalDbContext context) : base(context)
        {

        }
    }
}
