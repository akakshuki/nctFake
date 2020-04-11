using Api.Models.Dao;
using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
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
                ID = data.ID,
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
                ID= s.ID,
                PlaylistName = s.PlaylistName,
                PlaylistDescription = s.PlaylistDescription,
                PlaylistImage = s.PlaylistImage,
                CateID = s.CateID,
                UserID = s.UserID,            
            });
            return data;
        }

        public bool CreatePlaylist(PlaylistDTO playlistDTO)
        {
            string fileName = "";
            if (playlistDTO.FileData != null)
            {
                fileName = DateTime.Now.Ticks.ToString();
                string filePath = "~/File/ImageUser/" + Path.GetFileName(fileName + ".jpg");
                File.WriteAllBytes(System.Web.HttpContext.Current.Server.MapPath(filePath), Convert.FromBase64String(playlistDTO.FileData));
                fileName = fileName + ".jpg";
            }
            else
            {
                fileName = "default";
            }
            try
            {

                var data = new PlaylistDao().CreatePlaylist(new Playlist()
                {
                    PlaylistName = playlistDTO.PlaylistName,
                    UserID = playlistDTO.UserID,
                    CateID = playlistDTO.CateID,
                    PlaylistImage = fileName,
                    PlaylistDescription = playlistDTO.PlaylistDescription
                });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
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