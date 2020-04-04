using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models.Bus;
using Api.Models.Dao;
using ModelViews.DTOs;

namespace Api.Models
{
    public class Repositories
    {
        #region Musics

        public List<MusicDTO> GetListMusicByPage(Pagination pagination)
        {
            return new MusicBus().GetListMusicWithPage(pagination);
        }

        public void CreateMusic(MusicDTO music)
        {
            new MusicBus().AdminCreateMusic(music);
        }

        public bool UpdateMusic(MusicDTO music)
        {
            return new MusicBus().AdminUpdateMusic(music);
        }
        public bool DeleteMusic(int id)
        {
            return new MusicBus().AdminDeleteMusic(id);
        }

        public List<MusicDTO> FindMusicByName(string key)
        {
            return new MusicBus().SearchMusic(key);
        }

        public List<MusicDTO> GetAllMusic()
        {
            return new MusicBus().GetListMusicAll();
        }

        public MusicDTO GetMusicById(int id)
        {
            return new MusicBus().MusicById(id);
        }

        public List<MusicDTO> GetMusicByKey(string key)
        {
            return new MusicBus().SearchMusic(key);
        }

        #endregion

        #region PackedVip

        public IEnumerable<PackageVipDTO> GetAllPackageVip()
        {
            return new PackageVipBus().GetAllPackageVip();
        }

        public PackageVipDTO GetPackageVipById(int id)
        {
            return new PackageVipBus().GetPackageVipById(id);
        }

        public bool CreatePackageVip(PackageVipDTO packageVip)
        {
            return new PackageVipBus().CreatePackageVip(packageVip);
        }

        public bool UpdatePackageVip(PackageVipDTO packageVip)
        {
            return new PackageVipBus().UpdatePackageVip(packageVip);
        }

        public bool DeletePackageVip(int id)
        {
            return new PackageVipBus().DeletePackageVip(id);
        }

        #endregion

        #region Payment

        public IEnumerable<PaymentDTO> GetAllPayment()
        {
            return new PaymentBus().GetAllPayment();
        }


        public PaymentDTO GetPaymentById(int id)
        {
            return new PaymentBus().GetPaynemtById(id);

        }

        public bool CreatePayment(PaymentDTO payment)
        {
            return new PaymentBus().CreateNewPayment(payment);
        }

        public bool UpdatePayment(PaymentDTO payment)
        {
            return new PaymentBus().UpdatePayment(payment);
        }

        public bool DeletePayment(int id)
        {
            return new PaymentBus().DeletePayment(id);
        }

        #endregion



        #region Quality

        public IEnumerable<QualityDTO> GetAllQuality()
        {
           return  new QualityBus().GetAllQuality();
        }

        public QualityDTO  GetQualityById(int id)
        {
            return new QualityBus().GetQualityById(id);
        }

        #endregion

        public bool CreateQuality(QualityDTO quality)
        {
            return new QualityBus().CreateQuality(quality);
        }

        public bool UpdateQuality(QualityDTO quality)
        {
            return new QualityBus().UpdateQuality(quality);
        }
        public bool DeleteQuality(int id)
        {
            return new QualityBus().DeleteQuality(id);
        }


    }
}