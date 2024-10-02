using DatabaseSync.Business.Result;

namespace DatabaseSync.Business.Service.Interface
{
    public interface ISyncService
    {
        Task<SyncProcessResult> SyncDataAsync();
    }
}
