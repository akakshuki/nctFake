using Api.Models.Dao;
using Api.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.Bus
{
    public class PlaylistBus
    {
        public List<Playlist> GetAllPlaylist()
        {
            return new PlaylistDao().GetAllPlaylist();
        }
        public Playlist GetPlaylistById(int id)
        {
            return new PlaylistDao().GetPlaylistById(id);
        }
        public List<Playlist> GetPlaylistByIdUser(int id)
        {
            return new PlaylistDao().GetPlaylistByIdUser(id);
        }
        public bool CreatePlaylist(Playlist playlist)
        {
            if (new PlaylistDao().CreatePlaylist(playlist))
            {
                return true;
            }
            return false;
        }
        public bool UpdatePlaylist(Playlist playlist)
        {
            if (new PlaylistDao().UpdatePlaylist(playlist))
            {
                return true;
            }
            return false;
        }
        public bool DeletePlaylist(int id)
        {
            if (new PlaylistDao().DeletePlaylist(id))
            {
                return true;
            }
            return false;
        }
    }
}