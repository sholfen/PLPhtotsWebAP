﻿using PLPhtotsWebAP.Models;
using PLPhtotsWebAP.Repository;

namespace PLPhtotsWebAP.Services
{
    public class AlbumAppService : IAlbumAppService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumAppService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public Task<AlbumData> AddAlbum(AlbumData album)
        {
            return _albumRepository.AddAlbum(album);
        }
    }
}
