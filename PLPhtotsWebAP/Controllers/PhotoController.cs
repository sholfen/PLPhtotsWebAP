using Microsoft.AspNetCore.Mvc;
using PLPhtotsWebAP.Models;
using PLPhtotsWebAP.Services;

namespace PLPhtotsWebAP.Controllers
{
    public class PhotoController : Controller
    {
        private IPictureAppService _pictureAppService;

        public PhotoController(IPictureAppService pictureAppService)
        {
            _pictureAppService = pictureAppService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var list = await _pictureAppService.GetAllPicData();
            ViewData["PictureDatas"] = list;

            return View();
        }

        [HttpGet("/ImagePage/{id}")]
        public IActionResult Single(string id)
        {
            var url = _pictureAppService.GetImageUrlByRowKey(id);
            ViewData["Img"] = url;
            return View();
        }
    }
}
