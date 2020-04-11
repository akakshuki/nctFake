﻿using Api.Models.Dao;
using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Models.Bus
{
    public class QualityMusicBus
    {
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
                    QualityName = s.Quality.QualityName
                }
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
                    QualityDto = new QualityDTO
                    {
                        QualityName = data.Quality.QualityName
                    }
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public IEnumerable<QualityMusicDTO> GetFileByIdMusic(int id)
        {
            var data = new QualityMusicDao().GetFileByIdMusic(id).Select(s => new QualityMusicDTO
            {
                ID = s.ID,
                MusicID = s.MusicID,
                MusicFile = s.MusicFile,
                QualityID = s.QualityID,
                QMusicApproved = s.QMusicApproved,
                NewFile = s.NewFile,
                QualityDto = new QualityDTO
                {
                    QualityName = s.Quality.QualityName
                }
            });
            return data;
        }

        public bool CreateQualityMusic(QualityMusicDTO quality)
        {
            try
            {
                new QualityMusicDao().Create(new QualityMusic()
                {
                    MusicFile = "default",//co file sua sau
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
                new QualityMusicDao().Update(new QualityMusic()
                {
                    ID = quality.ID,
                    QMusicApproved = quality.QMusicApproved,
                    NewFile = false,
                    MusicFile = "default",//co file sua sau
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
        public bool UpdateQualityMusic(QualityMusicDTO quality)
        {
            try
            {
                new QualityMusicDao().Update(new QualityMusic()
                {
                    MusicFile = "default",//co file sua sau
                    ID = quality.ID,
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
    }
}