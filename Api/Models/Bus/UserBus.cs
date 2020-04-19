using Api.Models.Dao;
using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Api.Models.Bus
{
    public class UserBus
    {
        private string baseUrl = "";

        public UserBus()
        {
            baseUrl = "https://localhost:44315/File/ImageUser/";
        }
        public List<UserDTO> GetAllUser()
        {
            var data = new UserDao().GetAllUser().Where(s => s.UserVIP == false & s.RoleID == 3).OrderByDescending(s => s.UserDayCreate).Select(s => new UserDTO
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
                RoleDto = new RoleDTO()
                {
                    ID = s.Role.ID,
                    RoleName = s.Role.RoleName
                }
            }).ToList();
            return data;
        }
        public IEnumerable<User> GetAllUserNormal()
        {
            var data = new UserDao().GetAllUser().Where(s=>s.UserVIP == false & s.RoleID == 3).OrderByDescending(s => s.UserDayCreate).Select(s => new User
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
        public IEnumerable<User> GetAllUserVip()
        {
            var data = new UserDao().GetAllUser().Where(s => s.UserVIP == true).OrderByDescending(s => s.UserDayCreate).Select(s => new User
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
        public IEnumerable<User> GetAllSinger()
        {
            var data = new UserDao().GetAllUser().Where(s => s.RoleID == 2).OrderByDescending(s => s.UserDayCreate).Select(s => new User
            {
                ID = s.ID,
                UserName = s.UserName,
                UserDOB = s.UserDOB,
                UserGender = s.UserGender,
                UserNameUnsigned = s.UserNameUnsigned,
                UserDescription = s.UserDescription,
                UserDayCreate = s.UserDayCreate,
                RoleID = s.RoleID,
                UserImage = s.UserImage,
                Role = new Role()
                {
                    ID = s.Role.ID,
                    RoleName = s.Role.RoleName
                }
            });
            return data;
        }

        public UserDTO GetUserById(int id)
        {
            var data = new UserDao().GetUserById(id);
            return new UserDTO
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
                LinkImage = baseUrl + data.UserImage,
                RoleDto = new RoleDTO()
                {
                    ID = data.Role.ID,
                    RoleName = data.Role.RoleName,
                }
                
            };
        }

        public IEnumerable<User> GetUserByIdRole(int id)
        {
            var data = new UserDao().GetUserByIdRole(id).OrderByDescending(s => s.UserDayCreate).Select(s => new User
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

        public bool CreateSinger(UserDTO userDTO)
        {
            try
            {
                
                var data = new UserDao().CreateUser(new User()
                {
                    UserNameUnsigned = userDTO.UserNameUnsigned,
                    UserDescription = userDTO.UserDescription,
                    UserPwd = userDTO.UserPwd,
                    UserEmail = userDTO.UserEmail,
                    UserImage = userDTO.UserImage,
                    UserGender = userDTO.UserGender,
                    UserDOB = userDTO.UserDOB,
                    UserName = userDTO.UserName,
                    UserVIP = false,
                    UserActive = true,
                    RoleID = 2,
                    UserDayCreate = DateTime.Now,
                    DayVipEnd = null
                });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool CreateUser(UserDTO userDTO)
        {

            try
            {
                ProjectNCTEntities db = new ProjectNCTEntities();
                if (db.Users.Where(s => s.UserEmail == userDTO.UserEmail).Count() <= 0)
                {
                    var data = new UserDao().CreateUser(new User()
                    {
                        UserNameUnsigned = userDTO.UserNameUnsigned,
                        UserDescription = userDTO.UserDescription,
                        UserImage = userDTO.UserImage,
                        UserPwd = userDTO.UserPwd,
                        UserEmail = userDTO.UserEmail,
                        UserGender = userDTO.UserGender,
                        UserDOB = userDTO.UserDOB,
                        UserName = userDTO.UserName,
                        UserVIP = false,
                        UserActive = true,
                        RoleID = 3,
                        UserDayCreate = DateTime.Now,
                        DayVipEnd = null
                    });
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public bool UpdateSinger(User user)
        {
            if (new UserDao().UpdateSinger(user))
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



        //user convert dto
        public UserDTO GetUserDtoById(int id)
        {
        
            var data = new UserDao().GetUserById(id);
            return new UserDTO
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
                RoleDto = new RoleDTO()
                {
                    ID = data.Role.ID,
                    RoleName = data.Role.RoleName
                }
            };
        }

        public void UserResetPassword(UserDTO userDto)
        {
            new UserDao().ResetPassword(userDto);
        }

        public void CheckUserVip(string email)
        { 
            var user = new UserDao().GetAllUser().SingleOrDefault(x=>x.UserEmail== email);
            if (user != null && user.DayVipEnd <= DateTime.Now)
            {
                new UserDao().UpdateUserVip(email);
            }
        }
    }

}