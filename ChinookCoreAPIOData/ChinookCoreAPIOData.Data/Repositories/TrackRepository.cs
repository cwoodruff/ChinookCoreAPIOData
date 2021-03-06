﻿using System.Linq;
using System.Collections.Generic;
using ChinookCoreAPIOData.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ChinookCoreAPIOData.Domain.Repositories;

namespace ChinookCoreAPIOData.Data.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly ChinookContext _context;

        public TrackRepository(ChinookContext context)
        {
            _context = context;
        }

        private bool TrackExists(int id) =>
            _context.Track.Any(i => i.TrackId == id);

        public void Dispose() => _context.Dispose();

        public List<Track> GetAll() =>
            _context.Track.AsNoTracking().ToList();

        public Track GetById(int id) =>
            _context.Track.Find(id);

        public Track Add(Track newTrack)
        {
            _context.Track.Add(newTrack);
            _context.SaveChanges();
            return newTrack;
        }

        public bool Update(Track track)
        {
            if (!TrackExists(track.TrackId))
                return false;
            _context.Track.Update(track);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            if (!TrackExists(id))
                return false;
            var toRemove = _context.Track.Find(id);
            _context.Track.Remove(toRemove);
            _context.SaveChanges();
            return true;
        }

        public decimal GetMostExpensiveTrack()
        {
            return _context.Track.Max(t => t.UnitPrice);
        }

        public List<Track> GetByAlbumId(int id) =>
            _context.Track.Where(a => a.AlbumId == id).ToList();

        public List<Track> GetByGenreId(int id) =>
            _context.Track.Where(a => a.GenreId == id).ToList();

        public List<Track> GetByMediaTypeId(int id) =>
            _context.Track.Where(a => a.MediaTypeId == id).ToList();
    }
}