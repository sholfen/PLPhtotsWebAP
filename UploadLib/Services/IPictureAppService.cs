﻿using UploadLib.Models;

namespace UploadLib.Services
{
    public interface IPictureAppService
    {
        Task AddPicData(PictureData pictureData, Stream stream);
        Task AddThumbPicData(PictureData pictureData, Stream stream);
        Task ResizePic(List<FileInfo> browserFiles);
        Task<List<PictureData>> GetAllPicData();
        Task<List<PictureData>> GetAllThumbPicData();
        string GetImageUrlByRowKey(string rowkey);
        Task<List<PictureData>> GetPictureDataByPaging(int pageIndex, int pageSize);
    }
}
