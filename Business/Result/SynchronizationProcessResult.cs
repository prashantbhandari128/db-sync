namespace DatabaseSync.Business.Result
{
    public class SynchronizationProcessResult
    {
        public bool Status { get; set; }
        public bool ChangedLocally { get; set; }
        public string Message { get; set; } = string.Empty;

        public SynchronizationProcessResult(bool status, bool changedLocally, string message)
        {
            Status = status;
            ChangedLocally = changedLocally;
            Message = message;
        }

        public SynchronizationProcessResult SetResult(bool status, bool changedLocally, string message)
        {
            Status = status;
            ChangedLocally = changedLocally;
            Message = message;
            return this;
        }
    }
}
