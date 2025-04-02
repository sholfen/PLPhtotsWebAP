using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PLPhtotsWebAP.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
