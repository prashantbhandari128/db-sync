﻿using DatabaseSync.Persistence.Context;
using DatabaseSync.Persistence.Entities;
using DatabaseSync.Persistence.Repository.Interface.Server;

namespace DatabaseSync.Persistence.Repository.Implementation.Server
{
    public class ServerCustomerRepository : ServerRepository<Customer>, IServerCustomerRepository
    {
        public ServerCustomerRepository(ServerDbContext context) : base(context)
        {

        }
    }
}
