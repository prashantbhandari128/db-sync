using DatabaseSync.Persistence.Context;
using DatabaseSync.Persistence.Entities;
using DatabaseSync.Persistence.Repository.Interface.Local;

namespace DatabaseSync.Persistence.Repository.Implementation.Local
{
    public class LocalSyncLogRepository : LocalRepository<SyncLog>, ILocalSyncLogRepository
    {
        public LocalSyncLogRepository(LocalDbContext context) : base(context)
        {

        }
    }
}
