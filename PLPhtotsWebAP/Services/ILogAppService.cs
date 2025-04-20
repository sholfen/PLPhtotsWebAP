using PLPhtotsWebAP.Models;

namespace PLPhtotsWebAP.Services
{
    public interface ILogAppService
    {
        Task AddData(LogData data);
        Task<List<LogData>> GetAllLogData();
    }
}
