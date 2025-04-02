using Microsoft.AspNetCore.Mvc;

namespace PLPhtotsWebAP.Controllers
{
    public class LabsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
