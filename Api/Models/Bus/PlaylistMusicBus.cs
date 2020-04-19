using Api.Models.Dao;
using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.Bus
{
    public class PlaylistMusicBus
    {
        private string baseUrl = "";
        private string baseUrl1 = "";

        public PlaylistMusicBus()
        {
            baseUrl = "https://localhost:44315/File/mp3-mp4/";
            baseUrl1 = "https://localhost:44315/File/mp3-mp4/";
        }
        public List<PlaylistMusicDTO> GetMusicByIdPlaylist(int id)
        {
            var data = new PlaylistMusicDao().GetMusicByIdPlaylist(id).Select(s => new PlaylistMusicDTO 
            {
                ID = s.ID,
                MusicID = s.MusicID,
                PlaylistID = s.PlaylistID,
                MusicDto = new MusicDTO
                {
                    ID = s.Music.ID,
                    MusicName = s.Music.MusicName,
                    MusicView = s.Music.MusicView,
                    MusicImage = s.Music.MusicImage,
                    LinkImage = baseUrl1 + s.Music.MusicImage,
                    SingerMusicDtOs = new SingerMusicDao()
                        .GetAll()
                        .Where(x => x.MusicID == s.Music.ID)
                        .Select(x => new SingerMusicDTO()
                        {
                            ID = x.ID,
                            MusicID = x.MusicID,
                            SingerID = x.SingerID,
                            UserDto = new UserBus().GetUserDtoById(x.SingerID),
                        }).ToList(),
                    QualityMusicDTOs = new QualityMusicBus().GetFileByIdMusic(s.Music.ID)
                        .Where(d => d.QualityDto.QualityVip == false)
                        .Select(d => new QualityMusicDTO()
                        {
                            ID = d.ID,
                            MusicFile = d.MusicFile,
                            LinkFile = baseUrl + d.MusicFile,
                            MusicID = d.MusicID,
                            QualityID = d.QualityID,
                            
                        }),

                },
                
            }).ToList();
            return data;
        }

        public List<PlaylistMusicDTO> GetAllPlaylistMusic()
        {
            var data = new PlaylistMusicDao().GetAllPlaylistMusic().Select(s => new PlaylistMusicDTO
            {
                ID = s.ID,
                MusicID = s.MusicID,
                PlaylistID = s.PlaylistID,
                MusicDto = new MusicDTO
                {
                    ID = s.Music.ID,
                    MusicName = s.Music.MusicName,
                    MusicView = s.Music.MusicView,
                    MusicImage = s.Music.MusicImage,
                    LinkImage = baseUrl1 + s.Music.MusicImage,
                    SingerMusicDtOs = new SingerMusicDao()
                        .GetAll()
                        .Where(x => x.MusicID == s.Music.ID)
                        .Select(x => new SingerMusicDTO()
                        {
                            ID = x.ID,
                            MusicID = x.MusicID,
                            SingerID = x.SingerID,
                            UserDto = new UserBus().GetUserDtoById(x.SingerID)
                        }).ToList(),
                    QualityMusicDTOs = new QualityMusicBus().GetFileByIdMusic(s.Music.ID)
                        .Where(d => d.QualityDto.QualityVip == false)
                        .Select(d => new QualityMusicDTO()
                        {
                            ID = d.ID,
                            LinkFile = baseUrl + d.MusicFile,
                        }),
                },

            }).ToList();
            return data;
        }

        //public PlaylistMusicDTO GetIdMusicByIdPlaylist(int id)
        //{
        //    var data = new PlaylistMusicDao().GetMusicByIdPlaylist(id);
        //    return new PlaylistMusicDTO
        //    {
        //        ID = data
        //    };

        //}

        public bool CreatePlaylistMusic(PlaylistMusic playlistMusic)
        {
            if (new PlaylistMusicDao().CreatePlaylist(playlistMusic))
            {
                return true;
            }
            return false;
        }
        public bool DeletePlaylistMusic(int id)
        {
            if (new PlaylistMusicDao().DeletePlaylist(id))
            {
                return true;
            }
            return false;
        }
    }
}