﻿using Api.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.Dao
{
    public class PlaylistDao
    {
        private ProjectNCTEntities db = null;
        public PlaylistDao()
        {
            db = new ProjectNCTEntities();
        }
        public List<Playlist> GetAllPlaylist()
        {
            return db.Playlists.ToList();
        }
        public Playlist GetPlaylistById(int id)
        {
            var data = db.Playlists.SingleOrDefault(s => s.ID == id);
            return data;
        }
        public List<Playlist> GetPlaylistByIdUser(int id)
        {
            var data = db.Playlists.Where(s => s.UserID == id).ToList();
            return data;
        }
        public bool CreatePlaylist(Playlist playlist)
        {
            db.Playlists.Add(playlist);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdatePlaylist(Playlist playlist)
        {
            var data = db.Playlists.SingleOrDefault(s => s.ID == playlist.ID);
            data.PlaylistName = playlist.PlaylistName;
            data.PlaylistImage = playlist.PlaylistImage;
            data.PlaylistDescription = playlist.PlaylistDescription;
            data.CateID = playlist.CateID;
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeletePlaylist(int id)
        {
            var data = db.Playlists.SingleOrDefault(s => s.ID == id);
            db.Playlists.Remove(data);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}