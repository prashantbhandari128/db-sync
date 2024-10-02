namespace DatabaseSync.Business.Service.Interface
{
    public interface ILogService
    {
        Task<List<string>> GetAllSyncLogsForViewAsync();
        Task<int> SaveLogAsync(string message);
        Task<int> SaveLogsAsync(List<string> messages);
    }
}
