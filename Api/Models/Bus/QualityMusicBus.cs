using Api.Models.Dao;
using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.Bus
{
    public class QualityMusicBus
    {
        private string baseUrl = "";

        public QualityMusicBus()
        {
            baseUrl = "https://localhost:44315/File/mp3-mp4/";
        }
        #region Admin
        public IEnumerable<QualityMusicDTO> GetAllQM()
        {
            var data = new QualityMusicDao().GetAll().Where(s => s.QMusicApproved == false).Select(s => new QualityMusicDTO
            {
                ID = s.ID,
                MusicID = s.MusicID,
                MusicFile = s.MusicFile,
                QualityID = s.QualityID,
                QMusicApproved = s.QMusicApproved,
                NewFile = s.NewFile,
                QualityDto = new QualityDTO
                {
                    ID = s.Quality.ID,
                    QualityName = s.Quality.QualityName
                },
                LinkFile = baseUrl + s.MusicFile,
            });
            return data;
        }
        
        public QualityMusicDTO GetQualityMusicById(int id)
        {
            try
            {
                var data = new QualityMusicDao().FindById(id);
                return new QualityMusicDTO()
                {
                    ID = data.ID,
                    MusicID = data.MusicID,
                    MusicFile = data.MusicFile,
                    QualityID = data.QualityID,
                    QMusicApproved = data.QMusicApproved,
                    NewFile = data.NewFile,
                    LinkFile = baseUrl + data.MusicFile,
                    QualityDto = new QualityDTO
                    {
                        QualityName = data.Quality.QualityName,
                        ID = data.QualityID,
                        QualityVip = data.Quality.QualityVip
                    },
                    MusicDto = new MusicBus().MusicById(data.MusicID)
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public List<QualityMusicDTO> GetFileByIdMusic(int id)
        {
            var data = new QualityMusicDao().GetFileByIdMusic(id).Select(s => new QualityMusicDTO
            {
                ID = s.ID,
                MusicID = s.MusicID,
                MusicFile = s.MusicFile,
                QualityID = s.QualityID,
                QMusicApproved = s.QMusicApproved,
                NewFile = s.NewFile,
                LinkFile = baseUrl + s.MusicFile,
                QualityDto = new QualityDTO
                {
                    QualityName = s.Quality.QualityName,
                    ID = s.QualityID,
                    QualityVip = s.Quality.QualityVip
                }
            }).ToList();
            return data;
        }

        public bool CreateQualityMusic(QualityMusicDTO quality)
        {
            try
            {
                new QualityMusicDao().Create(new QualityMusic()
                {
                    MusicFile = quality.MusicFile,//co file sua sau
                    QMusicApproved = false,
                    QualityID = quality.QualityID,
                    NewFile = true,
                    MusicID = quality.MusicID,
                });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdateFile(QualityMusicDTO quality)
        {
            try
            {
                new QualityMusicDao().UpdateFile(new QualityMusic()
                {
                    ID = quality.ID,
                    QMusicApproved = quality.QMusicApproved,
                    NewFile = false,                                      
                    MusicID = quality.MusicID,
                });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public bool UpdateQualityMusic(QualityMusicDTO quality)
        {
            try
            {
                new QualityMusicDao().Update(new QualityMusic()
                {
                    MusicFile = quality.MusicFile,//co file sua sau
                    ID = quality.ID,
                    QualityID = quality.QualityID,                   
                    MusicID = quality.MusicID,
                });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeleteQualityMusic(int id)
        {
            try
            {
                new QualityMusicDao().Delete(id);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        #endregion Admin
        #region Client
        public QualityMusicDTO GetQualityMusicByIdMusic(int id)
        {
            var s = new QualityMusicDao().GetQualityMusicByIdMusic(id);
            return new QualityMusicDTO()
            {
                ID = s.ID,
                MusicID = s.MusicID,
                MusicFile = s.MusicFile,
                QualityID = s.QualityID,
                QMusicApproved = s.QMusicApproved,
                NewFile = s.NewFile,
                LinkFile = baseUrl + s.MusicFile,
                QualityDto = new QualityDTO
                {
                    QualityName = s.Quality.QualityName,
                    ID = s.QualityID,
                    QualityVip = s.Quality.QualityVip
                }
            };
        }
        #endregion
    }
}