using DatabaseSync.Business.Service.Interface;
using DatabaseSync.Persistence.UnitOfWork.Interface;
using DatabaseSync.View.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DatabaseSync.Business.Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ILocalUnitOfWork _localUnitOfWork;

        public CustomerService(ILocalUnitOfWork localUnitOfWork)
        {
            _localUnitOfWork = localUnitOfWork;
        }

        public async Task<List<CustomerViewModel>> GetAllLocalCustomersForViewAsync()
        {
            return await _localUnitOfWork.Customers.GetQueryable()
                .Include(x => x.Locations)
                .Select(x => new CustomerViewModel
                {
                    CustomerID = x.CustomerID,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    Addresses = x.Locations != null
                        ? string.Join(", ", x.Locations
                            .Where(l => l.Address != null)
                            .Select(l => l.Address))
                        : String.Empty
                })
                .ToListAsync();
        }
    }
}
