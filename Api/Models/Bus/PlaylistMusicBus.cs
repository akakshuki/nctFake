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
        public IEnumerable<PlaylistMusicDTO> GetMusicByIdPlaylist(int id)
        {
            var data = new PlaylistMusicDao().GetMusicByIdPlaylist(id).Select(s => new PlaylistMusicDTO 
            {
                ID = s.ID,
                MusicID = s.MusicID,
                PlaylistID = s.PlaylistID,
                MusicDto = new MusicDTO
                {
                    MusicName = s.Music.MusicName
                }
            });
            return data;
        }
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