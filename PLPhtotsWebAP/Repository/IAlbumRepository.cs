using PLPhtotsWebAP.Models;

namespace PLPhtotsWebAP.Repository
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<AlbumData>> GetAlbums();
        Task<AlbumData> GetAlbum(string id);
        Task<AlbumData> AddAlbum(AlbumData album);
        Task<AlbumData> UpdateAlbum(AlbumData album);
        Task DeleteAlbum(int id);
    }
}
