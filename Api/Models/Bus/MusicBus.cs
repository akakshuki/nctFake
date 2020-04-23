using Api.Models.Dao;
using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using Api.Models.Common;

namespace Api.Models.Bus
{
    public class MusicBus
    {
        private string baseUrl = "";

        public MusicBus()
        {
            baseUrl = "https://localhost:44315/File/ImageMusic/";
        }

        #region Admin

        //admin create new
        public void AdminCreateMusic(MusicDTO music)
        {
            //Save the Byte Array as File.
            try
            {
                var data = new MusicDao().Create(new Music()
                {
                    MusicDayCreate = DateTime.Now,
                    MusicName = music.MusicName,
                    MusicDownloadAllowed = true,
                    SongOrMV = music.SongOrMV,
                    CategoryId = music.CategoryId,
                    MusicImage = music.MusicImage,
                    MusicNameUnsigned = ConvertString.convertToUnSign2(music.MusicName),
                    MusicView = 0,
                    UserID = music.UserID,
                    MusicRelated = music.MusicRelated
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        //update music View
        public int UpdateView(int id)
        {
            return new MusicDao().UpdateView(id);
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
                CategoryId = music.CategoryId,
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
                    LinkImage = baseUrl + music.MusicImage,
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
                    CategoryId = music.CategoryId,
                    MusicView = music.MusicView,
                    ID = music.ID,
                    LinkImage = baseUrl + music.MusicImage,
                    QualityMusicDTOs = new QualityMusicBus()
                        .GetAllQM()
                        .Where(s => s.QualityID == 1 && s.QualityID == 3)
                        .Select(s => new QualityMusicDTO() 
                        {
                            ID = s.ID,
                            LinkFile = s.LinkFile,
                            MusicFile = s.MusicFile,
                            QMusicApproved = s.QMusicApproved,
                        }),
                    //need User
                    UserDto = new UserBus().GetUserDtoById(music.UserID),
                    SingerMusicDtOs = new SingerMusicDao()
                        .GetAll()
                        .Where(x => x.MusicID == music.ID)
                        .Select(x => new SingerMusicDTO()
                        {
                            ID = x.ID,
                            MusicID = x.MusicID,
                            SingerID = x.SingerID,
                            UserDto = new UserBus().GetUserDtoById(x.SingerID)
                        }).ToList(),
                    CategoryDto = new CategoryBus().GetAllListCategories().SingleOrDefault(x=>x.ID == music.CategoryId)
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
                    SingerMusicDtOs = new SingerMusicDao()
                        .GetAll()
                        .Where(x => x.MusicID == music.ID)
                        .Select(x => new SingerMusicDTO()
                        {
                            ID = x.ID,
                            MusicID = x.MusicID,
                            SingerID = x.SingerID,
                            UserDto = new UserBus().GetUserDtoById(x.SingerID)
                        }).ToList(),
                    UserDto = new UserBus().GetUserDtoById(music.UserID),
                };
                list.Add(newMusic);
            }

            return list;
        }


        public List<SingerMusicDTO> GetListSingerMusicByMusicId(int id)
        {
            return new SingerMusicDao()
                .GetAll()
                .Where(x => x.MusicID == id)
                .Select(x => new SingerMusicDTO()
                {
                    ID = x.ID,
                    MusicID = x.MusicID,
                    SingerID = x.SingerID,
                    UserDto = new UserBus().GetUserDtoById(x.SingerID)
                }).ToList();
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
                    CategoryId = music.CategoryId,
                    MusicDayCreate = music.MusicDayCreate,
                    MusicNameUnsigned = music.MusicNameUnsigned,
                    MusicView = music.MusicView,
                    ID = music.ID,
                    LinkImage = baseUrl + music.MusicImage,
                    //Edit later
                    
                    UserDto = new UserBus().GetUserDtoById(music.UserID),
                    CategoryDto = new CategoryBus().GetCateById(music.CategoryId),


                    SingerMusicDtOs = new SingerMusicDao()
                        .GetAll()
                        .Where(x => x.MusicID == music.ID)
                        .Select(x => new SingerMusicDTO()
                        {
                            ID = x.ID,
                            MusicID = x.MusicID,
                            SingerID = x.SingerID,
                            UserDto = new UserBus().GetUserDtoById(x.SingerID)
                        }).ToList()
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        #endregion Admin

        public void AddSingerToMusic(SingerMusicDTO singerMusic)
        {
            new SingerMusicDao().Create(new SingerMusic()
            {
                MusicID = singerMusic.MusicID,
                SingerID = singerMusic.SingerID
            });
        }

        public bool DeleteSingerToMusic(int id)
        {

            try
            {
                new SingerMusicDao().Delete(id);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }
        public List<MusicDTO> GetMusicByIdUser(int id)
        {
            var data = new MusicDao().GetMusicByIdUser(id).Select(s => new MusicDTO
            {
                ID = s.ID,
                UserID = s.UserID,
                MusicName = s.MusicName,
                MusicImage = s.MusicImage,
                SongOrMV = s.SongOrMV,
                MusicDownloadAllowed = s.MusicDownloadAllowed,
                MusicRelated = s.MusicRelated,
                MusicDayCreate = s.MusicDayCreate,
                MusicNameUnsigned = s.MusicNameUnsigned,
                CategoryId = s.CategoryId,
                MusicView = s.MusicView,
                LinkImage = baseUrl + s.MusicImage,
                UserDto = new UserBus().GetUserDtoById(s.UserID),
                SingerMusicDtOs = new SingerMusicDao()
                        .GetAll()
                        .Where(x => x.MusicID == s.ID)
                        .Select(x => new SingerMusicDTO()
                        {
                            ID = x.ID,
                            MusicID = x.MusicID,
                            SingerID = x.SingerID,
                            UserDto = new UserBus().GetUserDtoById(x.SingerID)
                        }).ToList(),
                QualityMusicDTOs = new QualityMusicBus()
                        .GetAllQM()
                        .Where(d => d.QualityID == 1 || d.QualityID == 3)
                        .Select(d => new QualityMusicDTO()
                        {
                            ID = d.ID,
                            LinkFile = d.LinkFile,
                            MusicFile = d.MusicFile,
                            QMusicApproved = d.QMusicApproved,
                            MusicID = d.MusicID
                        }),
               
            }).ToList();
            return data;
        }
        public bool DeleteLQ(int id)
        {
            return new MusicDao().DeleteLQ(id); 
        }
    }
}