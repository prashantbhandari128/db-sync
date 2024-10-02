namespace DatabaseSync.Business.Result
{
    public class SyncProcessResult
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public SyncProcessResult(bool status, string message)
        {
            Status = status;
            Message = message;
        }
        public SyncProcessResult SetResult(bool status, string message)
        {
            Status = status;
            Message = message;
            return this;
        }
    }
}
