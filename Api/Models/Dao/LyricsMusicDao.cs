using Api.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.Dao
{
    public class LyricsMusicDao
    {
        private ProjectNCTEntities db = null;

        public LyricsMusicDao()
        {
            db = new ProjectNCTEntities();
        }
        public LyricsMusic GetLyricByIdMusic(int id)
        {
            var data = db.LyricsMusics.SingleOrDefault(s=>s.MusicID == id);
            return data;
        }
        public LyricsMusic GetLyricById(int id)
        {
            var data = db.LyricsMusics.SingleOrDefault(s => s.ID == id);
            return data;
        }
        public bool Create(LyricsMusic lyricsMusic)
        {
            db.LyricsMusics.Add(lyricsMusic);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool Update(LyricsMusic lyricsMusic)
        {
            var data = db.LyricsMusics.SingleOrDefault(s=>s.ID == lyricsMusic.ID);
            data.LMusicDetail = lyricsMusic.LMusicDetail;
            data.MusicID = lyricsMusic.MusicID;
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}