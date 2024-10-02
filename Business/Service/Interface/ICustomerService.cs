using DatabaseSync.View.ViewModel;

namespace DatabaseSync.Business.Service.Interface
{
    public interface ICustomerService
    {
        Task<List<CustomerViewModel>> GetAllLocalCustomersForViewAsync();
    }
}
