using DatabaseSync.Persistence.Context;
using DatabaseSync.Persistence.Entities;
using DatabaseSync.Persistence.Repository.Interface.Server;

namespace DatabaseSync.Persistence.Repository.Implementation.Server
{
    public class ServerLocationRepository : ServerRepository<Location>, IServerLocationRepository
    {
        public ServerLocationRepository(ServerDbContext context) : base(context)
        {

        }
    }
}
