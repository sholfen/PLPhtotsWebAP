using Azure.Data.Tables;
using Azure.Storage.Blobs;
using PLPhtotsWebAP.Models;

namespace PLPhtotsWebAP.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly string _tableName = "AzurePicTable";
        private static readonly string PartitionKey = "LogData";
        public static string ContainerName = string.Empty;
        public static string TableConnectionString = string.Empty;
        private TableClient? _cosmosClient = null;

        public LogRepository()
        {
            Init();
        }

        public LogRepository(string connectionString)
        {
            Init();
        }

        private void Init()
        {
            TableServiceClient tableServiceClient = new TableServiceClient(TableConnectionString);
            TableClient tableClient = tableServiceClient.GetTableClient(tableName: _tableName);
            tableClient.CreateIfNotExistsAsync().Wait();
            _cosmosClient = tableClient;
        }

        public async Task AddData(LogData data)
        {
            await _cosmosClient.AddEntityAsync(data);
        }

        public async Task<List<LogData>> GetAllLogData()
        {
            var list = _cosmosClient.Query<LogData>(p => p.PartitionKey == PartitionKey)
                .OrderByDescending(l => l.LogDate)
                .ToList();
            return list;
        }
    }
}
