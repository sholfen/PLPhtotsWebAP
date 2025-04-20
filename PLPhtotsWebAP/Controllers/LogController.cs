using Microsoft.AspNetCore.Mvc;
using PLPhtotsWebAP.Services;

namespace PLPhtotsWebAP.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogAppService _logAppService;

        public LogController(ILogAppService logAppService)
        {
            _logAppService = logAppService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _logAppService.GetAllLogData();
            return new JsonResult(new { Data = list });
        }
    }
}
