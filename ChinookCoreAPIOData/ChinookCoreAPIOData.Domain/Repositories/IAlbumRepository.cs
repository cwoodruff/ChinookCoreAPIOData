﻿using System;
using System.Collections.Generic;
using ChinookCoreAPIOData.Domain.Entities;

namespace ChinookCoreAPIOData.Domain.Repositories
{
    public interface IAlbumRepository : IDisposable
    {
        List<Album> GetAll();
        Album GetById(int id);
        List<Album> GetByArtistId(int id);
        Album Add(Album newAlbum);
        bool Update(Album album);
        bool Delete(int id);
    }
}