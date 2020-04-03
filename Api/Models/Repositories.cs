using Api.Models.Bus;
using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Repositories
    {
        #region Category
        public IEnumerable<Category> GetAllCate()
        {
            return new CategoryBus().GetAllCate();
        }
        public Category GetCateById(int id)
        {
            return new CategoryBus().GetCateById(id);
        }
        public bool CreateCate(Category category)
        {
            if (new CategoryBus().CreateCate(category))
            {
                return true;
            }
            return false;
        }
        public bool UpdateCate(Category category)
        {
            if (new CategoryBus().UpdateCate(category))
            {
                return true;
            }
            return false;
        }
        public bool DeleteCate(int id)
        {
            if (new CategoryBus().DeleteCate(id))
            {
                return true;
            }
            return false;
        }
        #endregion
        #region Role
        public Role GetRoleById(int id)
        {
            return new RoleBus().GetRoleByID(id);
        }
        #endregion
        #region User
        public IEnumerable<User> GetAllUser()
        {
            return new UserBus().GetAllUser();
        }
        public User GetUserById(int id)
        {
            return new UserBus().GetUserById(id);
        }
        public IEnumerable<User> GetUserByIdRole(int id)
        {
            return new UserBus().GetUserByIdRole(id);
        }
        public bool CreateSinger(User user)
        {
            if (new UserBus().UpdateUser(user))
            {
                return true;
            }
            return false;
        }
        public bool CreateUser(User user)
        {
            if (new UserBus().UpdateUser(user))
            {
                return true;
            }
            return false;
        }
        public bool UpdateUser(User user)
        {
            if (new UserBus().UpdateUser(user))
            {
                return true;
            }
            return false;
        }
        public bool DeleteUser(int id)
        {
            if (new UserBus().DeleteUser(id))
            {
                return true;
            }
            return false;
        }
        #endregion
        #region Playlist
        public IEnumerable<Playlist> GetAllPlaylist()
        {
            return new PlaylistBus().GetAllPlaylist();
        }
        public Playlist GetPlaylistById(int id)
        {
            return new PlaylistBus().GetPlaylistById(id);
        }
        public IEnumerable<Playlist> GetPlaylistByIdUser(int id)
        {
            return new PlaylistBus().GetPlaylistByIdUser(id);
        }
        public bool CreatePlaylist(Playlist playlist)
        {
            if (new PlaylistBus().CreatePlaylist(playlist))
            {
                return true;
            }
            return false;
        }
        public bool UpdatePlaylist(Playlist playlist)
        {
            if (new PlaylistBus().UpdatePlaylist(playlist))
            {
                return true;
            }
            return false;
        }
        public bool DeletePlaylist(int id)
        {
            if (new PlaylistBus().DeletePlaylist(id))
            {
                return true;
            }
            return false;
        }
        #endregion
        #region Partner
        public IEnumerable<Partner> GetAllPartner()
        {
            return new PartnerBus().GetAllPartner();
        }
        public bool CreatePartner(Partner partner)
        {
            if (new PartnerBus().CreatePartner(partner))
            {
                return true;
            }
            return false;
        }
        public bool UpdatePartner(Partner partner)
        {
            if (new PartnerBus().UpdatePartner(partner))
            {
                return true;
            }
            return false;
        }
    }
    #endregion
}