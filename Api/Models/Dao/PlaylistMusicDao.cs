﻿using Api.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.Dao
{
    public class PlaylistMusicDao
    {
        private ProjectNCTEntities db = null;

        public PlaylistMusicDao()
        {
            db = new ProjectNCTEntities();
        }
        public List<PlaylistMusic> GetMusicByIdPlaylist(int id)
        {
            var data = db.PlaylistMusics.Where(s => s.PlaylistID == id).ToList();
            return data;
        }
        public bool CreatePlaylist(PlaylistMusic playlistMusic)
        {
            db.PlaylistMusics.Add(playlistMusic);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeletePlaylist(int id)
        {
            var data = db.PlaylistMusics.SingleOrDefault(s => s.ID  == id);
            db.PlaylistMusics.Remove(data);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}