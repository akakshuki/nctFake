using Api.Models.Dao;
using Api.Models.EF;
using ModelViews.DTOs;
using System;

namespace Api.Models.Bus
{
    public class QualityMusicBus
    {
        #region Admin

        public bool CreateQualityMusic(QualityMusicDTO quality)
        {
            try
            {
                new QualityMusicDao().Create(new QualityMusic()
                {
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

        public bool DeleteQuality(int id)
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