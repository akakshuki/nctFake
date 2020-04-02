using Api.Models.Dao;
using Api.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.Bus
{
    public class UserBus
    {
        public List<User> GetAllUser()
        {
            return new UserDao().GetAllUser();
        }
        public User GetUserById(int id)
        {
            return new UserDao().GetUserById(id);
        }
        public List<User> GetUserByIdRole(int id)
        {
            return new UserDao().GetUserByIdRole(id);
        }
        public bool CreateSinger(User user)
        {
            user.RoleID = 2;
            if (new UserDao().UpdateUser(user))
            {
                return true;
            }
            return false;
        }
        public bool CreateUser(User user)
        {
            user.RoleID = 3;
            if (new UserDao().UpdateUser(user))
            {
                return true;
            }
            return false;
        }
        public bool UpdateUser(User user)
        {
            if (new UserDao().UpdateUser(user))
            {
                return true;
            }
            return false;
        }
        public bool DeleteUser(int id)
        {
            if (new UserDao().DeleteUser(id))
            {
                return true;
            }
            return false;
        }
    }
}