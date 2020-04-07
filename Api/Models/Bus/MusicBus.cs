using Api.Models.Dao;
using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Api.Models.Common;

namespace Api.Models.Bus
{
    public class MusicBus
    {
        #region Admin

        //admin create new
        public void AdminCreateMusic(MusicDTO music)
        {
            //Save the Byte Array as File.

            string fileName = "";
            ; if (music.FileData != null)
            {
                fileName = DateTime.Now.Ticks.ToString();
                string filePath = "~/File/ImageMusic/" + Path.GetFileName(fileName + ".jpg");
                File.WriteAllBytes(System.Web.HttpContext.Current.Server.MapPath(filePath), Convert.FromBase64String(music.FileData));
                fileName = fileName + ".jpg";
            }
            else
            {
                fileName = "default";
            }
            try
            {
                var data = new MusicDao().Create(new Music()
                {
                    MusicDayCreate = DateTime.Now,
                    MusicName = music.MusicName,
                    MusicDownloadAllowed = true,
                    SongOrMV = music.SongOrMV,
                    MusicImage = fileName,
                    MusicNameUnsigned = ConvertString.convertToUnSign2(music.MusicName),
                    MusicView = 0,
                    UserID = music.UserID,

                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //update music
        public bool AdminUpdateMusic(MusicDTO music)
        {

            if (music.FileData != null)
            {

                string fileName = DateTime.Now.Ticks.ToString();
                string filePath = "~/File/ImageMusic/" + Path.GetFileName(fileName + ".jpg");
                File.WriteAllBytes(System.Web.HttpContext.Current.Server.MapPath(filePath), Convert.FromBase64String(music.FileData));
                fileName = fileName + ".jpg";
            }

            var data = new Music()
            {
                ID = music.ID,
                MusicDayCreate = DateTime.Now,
                MusicName = music.MusicName,
                MusicDownloadAllowed = music.MusicDownloadAllowed,
                SongOrMV = music.SongOrMV,
                UserID = music.UserID,
                MusicImage = music.MusicImage,
                MusicRelated = music.MusicRelated,
                MusicNameUnsigned = ConvertString.convertToUnSign2(music.MusicName),
            };
            try
            {
                new MusicDao().Update(data);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        //delete
        public bool AdminDeleteMusic(int id)
        {
            try
            {
                new MusicDao().Delete(id);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        //getListMusic have page
        public List<MusicDTO> GetListMusicWithPage(Pagination page)
        {
            var dataList = new MusicDao().GetPageMusic(page);

            return dataList.Select(music => new MusicDTO()
            {
                UserID = music.UserID,
                MusicName = music.MusicName,
                MusicImage = music.MusicImage,
                SongOrMV = music.SongOrMV,
                MusicDownloadAllowed = music.MusicDownloadAllowed,
                MusicRelated = music.MusicRelated,
                MusicDayCreate = music.MusicDayCreate,
                MusicNameUnsigned = music.MusicNameUnsigned,
                MusicView = music.MusicView,
                ID = music.ID,

                //need User
                UserDto = new UserBus().GetUserDtoById(music.UserID)
            })
                .ToList();
        }

        public List<MusicDTO> GetListMusicAll()
        {
            var list = new List<MusicDTO>();

            var dataList = new MusicDao().GetAll();

            foreach (var music in dataList)
            {
                var newMusic = new MusicDTO()
                {
                    UserID = music.UserID,
                    MusicName = music.MusicName,
                    MusicImage = music.MusicImage,
                    SongOrMV = music.SongOrMV,
                    MusicDownloadAllowed = music.MusicDownloadAllowed,
                    MusicRelated = music.MusicRelated,
                    MusicDayCreate = music.MusicDayCreate,
                    MusicNameUnsigned = music.MusicNameUnsigned,
                    MusicView = music.MusicView,
                    ID = music.ID,
                    //need User
                    UserDto = new UserBus().GetUserDtoById(music.UserID),
                };
                list.Add(newMusic);
            }
            return list;
        }

        //select by name

        public List<MusicDTO> SearchMusic(string namekey)
        {
            var list = new List<MusicDTO>();
            var dataList = new MusicDao()
                .GetAll()
                .Where(x => x.MusicName == namekey || x.MusicNameUnsigned == namekey)
                .ToList();
            foreach (var music in dataList)
            {
                var newMusic = new MusicDTO()
                {
                    UserID = music.UserID,
                    MusicName = music.MusicName,
                    MusicImage = music.MusicImage,
                    SongOrMV = music.SongOrMV,
                    MusicDownloadAllowed = music.MusicDownloadAllowed,
                    MusicRelated = music.MusicRelated,
                    MusicDayCreate = music.MusicDayCreate,
                    MusicNameUnsigned = music.MusicNameUnsigned,
                    MusicView = music.MusicView,
                    ID = music.ID,
                    //need User
                    UserDto = new UserBus().GetUserDtoById(music.UserID),
                };
                list.Add(newMusic);
            }
            return list;
        }

        public MusicDTO MusicById(int id)
        {
            try
            {
                var music = new MusicDao().FindById(id);
                return new MusicDTO()
                {
                    UserID = music.UserID,
                    MusicName = music.MusicName,
                    MusicImage = music.MusicImage,
                    SongOrMV = music.SongOrMV,
                    MusicDownloadAllowed = music.MusicDownloadAllowed,
                    MusicRelated = music.MusicRelated,
                    MusicDayCreate = music.MusicDayCreate,
                    MusicNameUnsigned = music.MusicNameUnsigned,
                    MusicView = music.MusicView,
                    ID = music.ID,
                    //Edit later
                    LinkImage = "https://localhost:44384/File/ImageMusic/" + music.MusicImage,
                    
                    UserDto = new UserBus().GetUserDtoById(music.UserID)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        #endregion Admin
    }
}