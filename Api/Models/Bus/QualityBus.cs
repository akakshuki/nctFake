using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models.Dao;
using Api.Models.EF;
using ModelViews.DTOs;

namespace Api.Models.Bus
{
    public class QualityBus
    {
        #region Admin
        //Get All  quality
        public List<QualityDTO> GetAllQuality()
        {
            var listData = new QualityDao().GetAll();
            var list = new List<QualityDTO>();
            foreach (var quality in listData)
            {
                var data = new QualityDTO()
                {
                    ID = quality.ID,
                    QualityName = quality.QualityName,
                    QualityVip = quality.QualityVip,
                };
                list.Add(data);
            }

            return list;
        }
        //create
        public bool CreateQuality(QualityDTO quality)
        {
            try
            {
                var data = new QualityDao().Create(new Quality()
                {
                    QualityName = quality.QualityName,
                    QualityVip = quality.QualityVip,
                });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        //Update
        public bool UpdateQuality(QualityDTO quality)
        {
            try
            {
                 new QualityDao().Update(new Quality()
                {
                    ID = quality.ID,
                    QualityName = quality.QualityName,
                    QualityVip = quality.QualityVip,
                });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        //delete
        public bool DeleteQuality(int id)
        {
            try
            {
                new QualityDao().Delete(id);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        #endregion

        public QualityDTO GetQualityById(int id)
        {
            try
            {
               var data = new QualityDao().FindById(id);
               return new QualityDTO()
               {
                   ID = data.ID,
                   QualityVip = data.QualityVip,
                   QualityName = data.QualityName
               };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}