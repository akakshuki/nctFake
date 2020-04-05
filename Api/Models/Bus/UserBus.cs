using Api.Models.Dao;
using Api.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Models.Bus
{
    public class UserBus
    {
        public IEnumerable<User> GetAllUser()
        {
            var data = new UserDao().GetAllUser().Select(s => new User
            {
                ID = s.ID,
                UserName = s.UserName,
                UserDOB = s.UserDOB,
                UserGender = s.UserGender,
                UserVIP = s.UserVIP,
                UserEmail = s.UserEmail,
                UserPwd = s.UserPwd,
                UserDescription = s.UserDescription,
                UserNameUnsigned = s.UserNameUnsigned,
                UserImage = s.UserImage,
                UserDayCreate = s.UserDayCreate,
                UserActive = s.UserActive,
                TokenUser = s.TokenUser,
                DayVipEnd = s.DayVipEnd,
                RoleID = s.RoleID,
                Role = new Role()
                {
                    ID = s.Role.ID,
                    RoleName = s.Role.RoleName
                }
            });
            return data;
        }

        public User GetUserById(int id)
        {
            var data = new UserDao().GetUserById(id);
            return new User
            {
                ID = data.ID,
                UserName = data.UserName,
                UserDOB = data.UserDOB,
                UserGender = data.UserGender,
                UserVIP = data.UserVIP,
                UserEmail = data.UserEmail,
                UserPwd = data.UserPwd,
                UserDescription = data.UserDescription,
                UserNameUnsigned = data.UserNameUnsigned,
                UserImage = data.UserImage,
                UserDayCreate = data.UserDayCreate,
                UserActive = data.UserActive,
                TokenUser = data.TokenUser,
                DayVipEnd = data.DayVipEnd,
                RoleID = data.RoleID,
                Role = new Role()
                {
                    ID = data.Role.ID,
                    RoleName = data.Role.RoleName
                }
            };
        }

        public IEnumerable<User> GetUserByIdRole(int id)
        {
            var data = new UserDao().GetUserByIdRole(id).Select(s => new User
            {
                ID = s.ID,
                UserName = s.UserName,
                UserDOB = s.UserDOB,
                UserGender = s.UserGender,
                UserVIP = s.UserVIP,
                UserEmail = s.UserEmail,
                UserPwd = s.UserPwd,
                UserDescription = s.UserDescription,
                UserNameUnsigned = s.UserNameUnsigned,
                UserImage = s.UserImage,
                UserDayCreate = s.UserDayCreate,
                UserActive = s.UserActive,
                TokenUser = s.TokenUser,
                DayVipEnd = s.DayVipEnd,
                RoleID = s.RoleID,
            });
            return data;
        }

        public bool CreateSinger(User user)
        {
            user.RoleID = 2;
            user.UserDayCreate = DateTime.Now;
            if (new UserDao().UpdateUser(user))
            {
                return true;
            }
            return false;
        }

        public bool CreateUser(User user)
        {
            user.RoleID = 3;
            user.UserDayCreate = DateTime.Now;
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