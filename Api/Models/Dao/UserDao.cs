using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Api.Models.Bus;

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
            return db.SaveChanges() > 0;
        }
        public bool UpdateUser(User user)
        {
            var data = db.Users.SingleOrDefault(s => s.ID == user.ID);
            if (data != null)
            {
                data.UserName = user.UserName;
                data.UserDOB = user.UserDOB;
                data.UserGender = user.UserGender;
                data.UserDescription = user.UserDescription;
                data.UserImage = user.UserImage;
            }

            return db.SaveChanges() > 0;
        }
        public bool DeleteUser(int id)
        {
            var data = db.Users.SingleOrDefault(s => s.ID == id);
            db.Users.Remove(data);
            return db.SaveChanges() > 0;
        }
        #region Login
        public int Login(string email, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserEmail == email);
            if (result == null)
            {
                return 0;
            }
            else
            {

                if (result.RoleID == CommonConstants.ADMIN_ROLE)
                {
                    if (result.UserPwd == passWord)
                    {
                        //      new UserBus().CheckUserVip(email);


                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
                else
                {
                    if (result.RoleID == CommonConstants.USER_ROLE)
                    {

                        if (result.UserPwd == passWord)
                        {
                            return -3;
                        }
                        else
                        {
                            return -2;
                        }

                    }
                }
                if (result.UserPwd == passWord)
                {
                    return 1;
                }
                else
                {
                    return -2;
                }

            }
        }
        public UserDTO GetIdLogin(string email)
        {
            var data = db.Users.Select(x => new UserDTO { UserEmail = x.UserEmail, ID = x.ID, UserName = x.UserName, DayVipEnd = x.DayVipEnd }).SingleOrDefault(x => x.UserEmail == email);
            return data;
        }
        #endregion


        public void ResetPassword(UserDTO userDto)
        {
            var data = db.Users.SingleOrDefault(x => x.UserEmail == userDto.UserEmail);
            data.UserPwd = userDto.UserPwd;
            db.SaveChanges();
        }

        public IEnumerable<UserDTO> GetListSingerSearch(string value)
        {
            var data = db.Users.Where(w => w.RoleID == 2 && (w.UserName.ToLower().Contains(value.ToLower()) || w.UserNameUnsigned.ToLower().Contains(value.ToLower()))).Select(x=> new UserDTO()
            {
                ID = x.ID,
                UserName = x.UserName
            } ).ToList();
            return data;

        }
        public void UpdateUserVip(string email)
        {
            var user = db.Users.SingleOrDefault(x => x.UserEmail == email);
            user.UserVIP = false;
           //user.DayVipEnd = null;
            db.SaveChanges();
        }
        public bool UpdatePassword(UserDTO userDTO)
        {
            var data = db.Users.SingleOrDefault(x =>x.ID == userDTO.ID && x.UserPwd == userDTO.AccountPwd) ?? null;
            if (data != null)
            {
                data.UserPwd = userDTO.UserPwd;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public void SetVipForUser(int dtoUserId, int month)
        {
            var user = db.Users.Find(dtoUserId);
            if (user != null)
            {
                if (user.DayVipEnd == null   )
                {
                    user.DayVipEnd = DateTime.Now.AddMonths(month);
                }else if (user.DayVipEnd <= DateTime.Now)
                {
                    user.DayVipEnd = DateTime.Now.AddMonths(month);
                }
                else
                {
                    var date = (DateTime)user.DayVipEnd;
                    user.DayVipEnd = date.AddMonths(month);
                }
                user.UserVIP = true;
                db.SaveChanges();
            }

            
            
        }
    }
}