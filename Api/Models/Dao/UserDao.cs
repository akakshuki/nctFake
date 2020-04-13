using Api.Models.EF;
using Glimpse.AspNet.Tab;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Models.Dao
{
    public class UserDao
    {
        private ProjectNCTEntities db = null;

        public UserDao()
        {
            db = new ProjectNCTEntities();
        }

        public List<User> GetAllUser()
        {
            var data = db.Users.ToList();
            return data;
        }

        public User GetUserById(int id)
        {
            var data = db.Users.SingleOrDefault(s => s.ID == id);
            return data;
        }

        public List<User> GetUserByIdRole(int id)
        {
            var data = db.Users.Where(s => s.RoleID == id).ToList();
            return data;
        }

        public bool CreateUser(User user)
        {
            try
            {
                db.Users.Add(user);
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }

        public bool UpdateSinger(User user)
        {
            var data = db.Users.SingleOrDefault(s => s.ID == user.ID);
            data.UserName = user.UserName;
            data.UserDOB = user.UserDOB;
            data.UserGender = user.UserGender;
            data.UserDescription = user.UserDescription;
            data.UserNameUnsigned = user.UserNameUnsigned;
            data.UserImage = user.UserImage;
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateUser(User user)
        {
            var data = db.Users.SingleOrDefault(s => s.ID == user.ID);
            data.UserName = user.UserName;
            data.UserDOB = user.UserDOB;
            data.UserGender = user.UserGender;
            data.UserVIP = user.UserVIP;
            data.UserEmail = user.UserEmail;
            data.UserPwd = user.UserPwd;
            data.UserDescription = user.UserDescription;
            data.UserNameUnsigned = user.UserNameUnsigned;
            data.UserImage = user.UserImage;
            data.Role = user.Role;
            data.UserActive = user.UserActive;
            data.DayVipEnd = user.DayVipEnd;
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteUser(int id)
        {
            var data = db.Users.SingleOrDefault(s => s.ID == id);
            db.Users.Remove(data);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}