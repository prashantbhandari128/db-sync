using DatabaseSync.Persistence.Context;
using DatabaseSync.Persistence.Entities;
using DatabaseSync.Persistence.Repository.Interface.Local;

namespace DatabaseSync.Persistence.Repository.Implementation.Local
{
    public class LocalLocationRepository : LocalRepository<Location>, ILocalLocationRepository
    {
        public LocalLocationRepository(LocalDbContext context) : base(context)
        {

        }
    }
}
