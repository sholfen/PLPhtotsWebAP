using ImageMagick;
using Microsoft.AspNetCore.Components.Forms;
using PLPhtotsWebAP.Models;
using PLPhtotsWebAP.Repository;

namespace PLPhtotsWebAP.Services
{
    public class PictureAppService : IPictureAppService
    {
        private IPictureRepository _pictureRepository;

        public PictureAppService(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }

        public async Task AddPicData(PictureData pictureData, Stream stream)
        {
            await _pictureRepository.AddPicData(pictureData, stream);
        }

        public async Task AddThumbPicData(PictureData pictureData, Stream stream)
        {
            await _pictureRepository.AddPicData(pictureData, stream);
        }

        public async Task<List<PictureData>> GetAllPicData()
        {
            List<PictureData> pictureDatas = await _pictureRepository.GetPictureDataList();

            return pictureDatas;
        }

        public async Task<List<PictureData>> GetAllThumbPicData()
        {
            return await _pictureRepository.GetAllThumbPicData();
        }

        public string GetImageUrlByRowKey(string rowkey)
        {
            return _pictureRepository.GetImageUrlByRowKey(rowkey);
        }

        public async Task ResizePic(List<IFormFile> browserFiles)
        {          
            //var stream = browserFile.OpenReadStream(maxAllowedSize: 512000000);

            foreach (var imageFile in browserFiles)
            {
                //var stream = imageFile.OpenReadStream(maxAllowedSize: 512000000);
                var stream = imageFile.OpenReadStream();
                var readSettings = new MagickReadSettings() { Format = MagickFormat.Jpeg, Interlace = Interlace.Jpeg };
                var memStream = new MemoryStream();
                var sourceStream = new MemoryStream();
                //await stream.CopyToAsync(memStream);
                stream.CopyTo(memStream);
                memStream.Position = 0;
                using var thumb = new MagickImage(memStream, readSettings);
                var size = new MagickGeometry(thumb.Width / 6, thumb.Height / 6)
                {
                    IgnoreAspectRatio = true
                };
                thumb.Write(sourceStream);
                thumb.Resize(size);
                string guid = Guid.NewGuid().ToString();
                PictureData thumbPicData = new PictureData
                {
                    Desc = string.Empty,
                    FileName = "thumb_" + $"{guid}_" + imageFile.Name,
                    ImageUrl = PictureRepository.CDNDomain + "thumb_" + $"{guid}_" + imageFile.Name,
                    IsThumb = true,
                    ThumbUrl = string.Empty,
                    Title = string.Empty
                };

                Stream? thumbStream = new MemoryStream();
                thumb.Write(thumbStream);
                //image.Save(thumbStream, ImageFormat.Jpeg);
                thumbStream.Position = 0;
                await AddPicData(thumbPicData, thumbStream);

                //Picture
                PictureData pictureData = new PictureData
                {
                    Desc = string.Empty,
                    FileName = $"{guid}_" + imageFile.Name,
                    ImageUrl = PictureRepository.CDNDomain + $"{guid}_" + imageFile.Name,
                    Title = string.Empty,
                    ThumbGuid = thumbPicData.RowKey,
                    ThumbUrl = thumbPicData.ImageUrl,
                    IsThumb = false
                };
                sourceStream.Position = 0;
                using var image = new MagickImage(sourceStream, readSettings);
                size = new MagickGeometry(image.Width / 2, image.Height / 2)
                {
                    IgnoreAspectRatio = true
                };
                image.Resize(size);
                Stream? orgStream = new MemoryStream();
                image.Write(orgStream);
                orgStream.Position = 0;
                await AddPicData(pictureData, orgStream);

                Task.WaitAll();
                thumbStream.Close();
                stream.Close();
            }
        }

        public async Task<List<PictureData>> GetPictureDataByPaging(int pageIndex, int pageSize)
        {
            return await _pictureRepository.GetPictureDataByPaging(pageIndex, pageSize);
        }
    }
}
