using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace PLPhtotsWebAP.Controllers
{
    public class VideoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Stream()
        //{
        //    //<video autoplay controls src="https://localhost:7093/video?id=1"></video> 
        //    var filename = "file_example.mp4";
        //    //Build the File Path.  
        //    string path =   filename;  // the video file is in the wwwroot/files folder  

        //    var filestream = System.IO.File.OpenRead(path);
        //    return Results.File(filestream, contentType: "video/mp4", fileDownloadName: filename, enableRangeProcessing: true);
        //}
    }
}
