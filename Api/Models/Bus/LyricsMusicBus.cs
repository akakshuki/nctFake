using Api.Models.Dao;
using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.Bus
{
    public class LyricsMusicBus
    {
        public LyricsMusicDTO GetLyricByIdMusic(int id)
        {
            var data = new LyricsMusicDao().GetLyricByIdMusic(id);
            return new LyricsMusicDTO 
            {
                ID = data.ID,
                LMusicDayCreate = data.LMusicDayCreate,
                LMusicDetail = data.LMusicDetail,
                MusicID = data.MusicID,
                UserID = data.UserID,       
                MusicDto = new MusicDTO
                {
                    MusicName = data.Music.MusicName,                 
                },
                UserDto = new UserBus().GetUserById(data.UserID)
            };
        }
        public LyricsMusicDTO GetLyricById(int id)
        {
            var data = new LyricsMusicDao().GetLyricById(id);
            return new LyricsMusicDTO
            {
                ID = data.ID,
                LMusicDayCreate = data.LMusicDayCreate,
                LMusicDetail = data.LMusicDetail,
                MusicID = data.MusicID,
                UserID = data.UserID,
                MusicDto = new MusicDTO
                {
                    MusicName = data.Music.MusicName
                }
            };
        }
        public bool Create(LyricsMusic lyricsMusic)
        {
            lyricsMusic.UserID = lyricsMusic.UserID;
            lyricsMusic.LMusicDayCreate = DateTime.Now;
            if (new LyricsMusicDao().Create(lyricsMusic))
            {
                return true;
            }
            return false;
        }
        public bool Update(LyricsMusic lyricsMusic)
        {
            lyricsMusic.UserID = lyricsMusic.UserID;
            if (new LyricsMusicDao().Update(lyricsMusic))
            {
                return true;
            }
            return false;
        }
    }
}