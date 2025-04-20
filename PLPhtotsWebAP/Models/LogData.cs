using Azure;
using Azure.Data.Tables;

namespace PLPhtotsWebAP.Models
{
    public class LogData: ITableEntity
    {
        public string RowKey { get; set; } = Guid.NewGuid().ToString();
        public string PartitionKey { get; set; } = "LogData";
        public ETag ETag { get; set; } = default!;
        public DateTimeOffset? Timestamp { get; set; } = default!;
        public string LogMessage { get; init; } = string.Empty;
        public string LogLevel { get; init; } = string.Empty;
        public DateTime LogDate { get; init; } = DateTime.UtcNow; 
    }
}
