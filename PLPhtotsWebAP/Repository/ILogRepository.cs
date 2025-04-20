using PLPhtotsWebAP.Models;

namespace PLPhtotsWebAP.Repository
{
    public interface ILogRepository
    {
        Task AddData(LogData data);
        Task<List<LogData>> GetAllLogData();
    }
}
