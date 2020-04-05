using Api.Models.Dao;
using Api.Models.EF;
using System.Collections.Generic;
using System.Linq;

namespace Api.Models.Bus
{
    public class PlaylistBus
    {
        public IEnumerable<Playlist> GetAllPlaylist()
        {
            var data = new PlaylistDao().GetAllPlaylist().Select(s => new Playlist
            {
                PlaylistName = s.PlaylistName,
                PlaylistDescription = s.PlaylistDescription,
                PlaylistImage = s.PlaylistImage,
                CateID = s.CateID,
                UserID = s.UserID
            });
            return data;
        }

        public Playlist GetPlaylistById(int id)
        {
            var data = new PlaylistDao().GetPlaylistById(id);
            return new Playlist
            {
                PlaylistName = data.PlaylistName,
                PlaylistDescription = data.PlaylistDescription,
                PlaylistImage = data.PlaylistImage,
                CateID = data.CateID,
                UserID = data.UserID
            };
        }

        public IEnumerable<Playlist> GetPlaylistByIdUser(int id)
        {
            var data = new PlaylistDao().GetPlaylistByIdUser(id).Select(s => new Playlist
            {
                PlaylistName = s.PlaylistName,
                PlaylistDescription = s.PlaylistDescription,
                PlaylistImage = s.PlaylistImage,
                CateID = s.CateID,
                UserID = s.UserID
            });
            return data;
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