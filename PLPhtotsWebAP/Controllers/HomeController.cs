using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PLPhtotsWebAP.Models;
using PLPhtotsWebAP.Services;

namespace PLPhtotsWebAP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILogAppService _logAppService;

        public HomeController(ILogger<HomeController> logger, ILogAppService logAppService)
        {
            _logger = logger;
            _logAppService = logAppService;
        }

        public async Task<IActionResult> Index()
        {
            LogData logData = new LogData
            {
                LogDate = DateTime.UtcNow,
                LogLevel = "Info",
                LogMessage = "Index page accessed",
            };
            await _logAppService.AddData(logData);
            return View();
        }

        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
