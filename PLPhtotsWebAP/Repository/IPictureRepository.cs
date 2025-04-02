using PLPhtotsWebAP.Models;

namespace PLPhtotsWebAP.Repository
{
    public interface IPictureRepository
    {
        Task AddPicData(PictureData pictureData, Stream stream);
        Task<PictureData> GetPictureData(string rowkey);
        Task<List<PictureData>> GetPictureDataList();
        Task<List<PictureData>> GetAllThumbPicData();
        string GetImageUrlByRowKey(string rowkey);
        Task<List<PictureData>> GetPictureDataByPaging(int pageIndex, int pageSize);
    }
}
