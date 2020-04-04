using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models.Dao;

using Api.Models.EF;
using ModelViews.DTOs;

namespace Api.Models.Bus
{
    public class MusicBus
    {
        #region Admin
        //admin create new
        public void AdminCreateMusic(MusicDTO music)
        {
            var data = new MusicDao().Create(new Music()
            {
                MusicDayCreate = DateTime.Now,
                MusicName = music.MusicName,
                MusicDownloadAllowed = true,
                SongOrMV = true,
                UserID = music.UserID,
                MusicImage = music.MusicImage,
                MusicView = 0,
            });
            try
            {
                var res = new MusicDao().Create(data);
                
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
                MusicNameUnsigned = music.MusicNameUnsigned,
                
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
            var list = new List<MusicDTO>();

            var dataList = new MusicDao().GetPageMusic(page);

            foreach (var music in dataList)
            {
                var newMusic = new MusicDTO()
                {
                     UserID =  music.UserID,
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
                     UserDto = null,
                };
                list.Add(newMusic);
            }
            return list;
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
                    UserDto = null,

                };
                list.Add(newMusic);
            }
            return list;
        }

        //select by name 

        public List<MusicDTO> SearchMusic(string namekey)
        {
            var list= new List<MusicDTO>();
            var dataList = new MusicDao()
                .GetAll()
                .Where(x=>x.MusicName==namekey|| x.MusicNameUnsigned == namekey)
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
                    UserDto = null,
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
                    //need User
                    UserDto = null
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        #endregion



        #region Client




        #endregion


    }
}   