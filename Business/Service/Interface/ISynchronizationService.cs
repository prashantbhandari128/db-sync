using DatabaseSync.Business.Result;

namespace DatabaseSync.Business.Service.Interface
{
    public interface ISynchronizationService
    {
        Task<SynchronizationProcessResult> SynchronizeDatabaseAsync();
    }
}
