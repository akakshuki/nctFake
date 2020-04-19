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
        private string baseUrl = "";

        public PlaylistBus()
        {
            baseUrl = "https://localhost:44315/File/ImagePlaylist/";
        }
        public IEnumerable<PlaylistDTO> GetAllPlaylist()
        {
            var data = new PlaylistDao().GetAllPlaylist().Select(s => new PlaylistDTO
            {
                ID = s.ID,
                PlaylistName = s.PlaylistName,
                PlaylistDescription = s.PlaylistDescription,
                PlaylistImage = s.PlaylistImage,
                CateID = s.CateID,
                UserID = s.UserID,
                CategoryDto = new CategoryBus().GetCateById(s.CateID ?? 0),
                UserDto = new UserBus().GetUserDtoById(s.UserID),
            });
            return data;
        }

        public PlaylistDTO GetPlaylistById(int id)
        {
            var data = new PlaylistDao().GetPlaylistById(id);
            return new PlaylistDTO
            {
                ID = data.ID,
                PlaylistName = data.PlaylistName,
                PlaylistDescription = data.PlaylistDescription,
                PlaylistImage = data.PlaylistImage,
                CateID = data.CateID,
                UserID = data.UserID,
                LinkImage = baseUrl + data.PlaylistImage,
                UserDto = new UserBus().GetUserDtoById(data.UserID),
            };
        }

        public PlaylistDTO GetPlaylistByCate(int id)
        {
            var data = new PlaylistDao().GetPlaylistByCate(id);
            return new PlaylistDTO
            {
                ID = data.ID,
                PlaylistName = data.PlaylistName,
                PlaylistDescription = data.PlaylistDescription,
                PlaylistImage = data.PlaylistImage,
                CateID = data.CateID,
                UserID = data.UserID,
                LinkImage = baseUrl + data.PlaylistImage,
                CategoryDto = new CategoryBus().GetCateById(data.CateID ?? 0),
                
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

        public List<PlaylistDTO> GetPlaylistByIdCate(int id)
        {
            try
            {
                var data = new PlaylistDao().GetPlaylistByIdCate(id).Select(s => new PlaylistDTO
                {
                    ID = s.ID,
                    PlaylistName = s.PlaylistName,
                    PlaylistDescription = s.PlaylistDescription,
                    PlaylistImage = s.PlaylistImage,
                    CateID = s.CateID,
                    UserID = s.UserID,
                    LinkImage = baseUrl + s.PlaylistImage,
                    UserDto = new UserBus().GetUserDtoById(s.UserID),
                    CategoryDto = new CategoryBus().GetCateById(s.CateID ?? 0),
                }).ToList();
                return data;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public bool CreatePlaylist(PlaylistDTO playlistDTO)
        {
            try
            {

                var data = new PlaylistDao().CreatePlaylist(new Playlist()
                {
                    PlaylistName = playlistDTO.PlaylistName,
                    UserID = playlistDTO.UserID,
                    CateID = playlistDTO.CateID,
                    PlaylistImage = playlistDTO.PlaylistImage,
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