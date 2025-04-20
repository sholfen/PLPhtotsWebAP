using PLPhtotsWebAP.Models;
using PLPhtotsWebAP.Repository;

namespace PLPhtotsWebAP.Services
{
    public class LogAppService : ILogAppService
    {
        private ILogRepository _logRepository;

        public LogAppService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }


        public async Task AddData(LogData data)
        {
            await _logRepository.AddData(data);
        }

        public async Task<List<LogData>> GetAllLogData()
        {
            var list = await _logRepository.GetAllLogData();
            return list;
        }
    }
}
