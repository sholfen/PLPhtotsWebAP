using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UploadLib.Repository;

namespace UploadLib.Services
{
    public class UploadFileService
    {
        private PictureAppService _pictureAppService;

        public UploadFileService()
        {
            IPictureRepository pictureRepository = new PictureRepository();
            _pictureAppService = new PictureAppService(pictureRepository);
        }

        public async Task UploadFile(List<FileInfo> fileInfos)
        {
            await _pictureAppService.ResizePic(fileInfos);
            // Upload file
        }
    }
}
