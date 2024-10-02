using System.ComponentModel.DataAnnotations;

namespace DatabaseSync.Persistence.Entities
{
    public class SyncLog
    {
        [Key]
        public int SyncId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; } = String.Empty;
    }
}
