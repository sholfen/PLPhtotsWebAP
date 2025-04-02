using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PLPhtotsWebAP.Services;
using System.Collections.Generic;

namespace PLPhtotsWebAP.Controllers
{
    public class UploadData
    {
        public List<IFormFile> files { get; set; }
    }

    [Authorize]
    public class UploadController : Controller
    {
        private IPictureAppService _pictureAppService;

        public UploadController(IPictureAppService pictureAppService)
        {
            _pictureAppService = pictureAppService;
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 256 * 1024 * 1024)]
        [RequestSizeLimit(256 * 1024 * 1024)]
        public async Task<IActionResult> UploadPics(UploadData model)
        {
            await _pictureAppService.ResizePic(model.files);
            return RedirectToAction("UploadPic", "Upload");
        }

        [HttpGet]
        public IActionResult UploadPic()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UploadAIPic()
        {
            return View();
        }
    }
}
