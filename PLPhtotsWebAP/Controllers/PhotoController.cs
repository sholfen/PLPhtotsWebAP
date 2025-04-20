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

        [HttpGet()]
        public async Task<IActionResult> List()
        {
            var list = await _pictureAppService.GetPictureDataByPaging(0, 20);
            ViewData["PictureDatas"] = list;
            ViewData["PageIndex"] = 0;
            return View();
        }

        [HttpGet("/Photo/List/{pageIndex}")]
        public async Task<IActionResult> List(int? pageIndex)
        {
            List<PictureData> list = new List<PictureData>();
            if (pageIndex == null)
            {
                pageIndex = 0;
                list = await _pictureAppService.GetPictureDataByPaging(0, 20);
                ViewData["PictureDatas"] = list;
                ViewData["PageIndex"] = pageIndex;
            }
            else
            {
                if (pageIndex.Value < 0)
                {
                    pageIndex = 0;
                }
                list = await _pictureAppService.GetPictureDataByPaging(pageIndex.Value, 20);
                ViewData["PictureDatas"] = list;
                ViewData["PageIndex"] = pageIndex.Value;
            }


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
