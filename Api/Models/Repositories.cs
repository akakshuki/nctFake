using System;
using Api.Models.Bus;
using Api.Models.EF;
using ModelViews.DTOs;
using System.Collections.Generic;

namespace Api.Models
{
    public class Repositories
    {
        #region Category

        public IEnumerable<Category> GetAllCate()
        {
            return new CategoryBus().GetAllCate();
        }

        public IEnumerable<Category> GetAllCateCon()
        {
            return new CategoryBus().GetAllCateCon();
        }

        public IEnumerable<CategoryDTO> GetAllListCate()
        {
            return new CategoryBus().GetAllListCategories();
        }
        public Category GetCateById(int id)
        {
            return new CategoryBus().GetCateById(id);
        }
        public IEnumerable<Category> GetCateByIdRoot(int id)
        {
            return new CategoryBus().GetCateByIdRoot(id);
        }
        public bool CreateCate(Category category)
        {
            if (new CategoryBus().CreateCate(category))
            {
                return true;
            }
            return false;
        }

        public bool UpdateCate(Category category)
        {
            if (new CategoryBus().UpdateCate(category))
            {
                return true;
            }
            return false;
        }

        public bool DeleteCate(int id)
        {
            if (new CategoryBus().DeleteCate(id))
            {
                return true;
            }
            return false;
        }

        #endregion Category

        #region Role

        public Role GetRoleById(int id)
        {
            return new RoleBus().GetRoleByID(id);
        }

        #endregion Role

        #region User

        public IEnumerable<User> GetAllUserNormal()
        {
            return new UserBus().GetAllUserNormal();
        }
        public IEnumerable<User> GetAllUserVip()
        {
            return new UserBus().GetAllUserVip();
        }
        public IEnumerable<User> GetAllSinger()
        {
            var data = new UserBus().GetAllSinger();
            return data;
        }
        public UserDTO GetUserById(int id)
        {
            return new UserBus().GetUserById(id);
        }

        public IEnumerable<User> GetUserByIdRole(int id)
        {
            return new UserBus().GetUserByIdRole(id);
        }

        public bool CreateSinger(UserDTO userDTO)
        {
            if (new UserBus().CreateSinger(userDTO))
            {
                return true;
            }
            return false;
        }

        public bool CreateUser(UserDTO userDTO)
        {
            if (new UserBus().CreateUser(userDTO))
            {
                return true;
            }
            return false;
        }

        public bool UpdateSinger(User user)
        {
            if (new UserBus().UpdateSinger(user))
            {
                return true;
            }
            return false;
        }

        public bool UpdateUser(User user)
        {
            if (new UserBus().UpdateUser(user))
            {
                return true;
            }
            return false;
        }

        public bool DeleteUser(int id)
        {
            if (new UserBus().DeleteUser(id))
            {
                return true;
            }
            return false;
        }

        #endregion User

        #region Playlist

        public IEnumerable<Playlist> GetAllPlaylist()
        {
            return new PlaylistBus().GetAllPlaylist();
        }

        public PlaylistDTO GetPlaylistById(int id)
        {
            return new PlaylistBus().GetPlaylistById(id);
        }

        public IEnumerable<Playlist> GetPlaylistByIdUser(int id)
        {
            return new PlaylistBus().GetPlaylistByIdUser(id);
        }

        public bool CreatePlaylist(PlaylistDTO playlist)
        {
            if (new PlaylistBus().CreatePlaylist(playlist))
            {
                return true;
            }
            return false;
        }

        public bool UpdatePlaylist(Playlist playlist)
        {
            if (new PlaylistBus().UpdatePlaylist(playlist))
            {
                return true;
            }
            return false;
        }

        public bool DeletePlaylist(int id)
        {
            if (new PlaylistBus().DeletePlaylist(id))
            {
                return true;
            }
            return false;
        }

        #endregion Playlist

        #region Partner

        public IEnumerable<PartnerDTO> GetAllPartner()
        {
            return new PartnerBus().GetAllPartner();
        }

        public PartnerDTO GetPartnerById(int id)
        {
            return new PartnerBus().GetPartnerById(id);
        }

        public bool CreatePartner(PartnerDTO partner)
        {
            if (new PartnerBus().CreatePartner(partner))
            {
                return true;
            }
            return false;
        }

        public bool UpdatePartner(PartnerDTO partner)
        {
            if (new PartnerBus().UpdatePartner(partner))
            {
                return true;
            }
            return false;
        }
        public bool DeletePartner(int id)
        {
            if (new PartnerBus().DeletePartner(id))
            {
                return true;
            }
            return false;
        }

        #endregion Partner

        #region Musics

        public List<MusicDTO> GetListMusicByPage(Pagination pagination)
        {
            return new MusicBus().GetListMusicWithPage(pagination);
        }

        public void CreateMusic(MusicDTO music)
        {
            new MusicBus().AdminCreateMusic(music);
        }

        public void AddSingerToMusic(SingerMusicDTO singerMusic)
        {
            new MusicBus().AddSingerToMusic(singerMusic);
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

        public List<SingerMusicDTO> SingerMusicByMusicId(int id)
        {
            return new MusicBus().GetListSingerMusicByMusicId(id);
        }
        public bool DeleteSingerMusic(int id)
        {
            return new MusicBus().DeleteSingerToMusic(id);
        }

        public MusicDTO GetMusicById(int id)
        {
            return new MusicBus().MusicById(id);
        }

        public List<MusicDTO> GetMusicByKey(string key)
        {
            return new MusicBus().SearchMusic(key);
        }

        #endregion Musics

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

        #endregion PackedVip

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

        #endregion Payment

        #region Quality

        public IEnumerable<QualityDTO> GetAllQuality()
        {
            return new QualityBus().GetAllQuality();
        }

        public QualityDTO GetQualityById(int id)
        {
            return new QualityBus().GetQualityById(id);
        }



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
        #endregion

        #region OrderVip
        public IEnumerable<OrderVipDTO> GetOrderVipByIdUser(int id) 
        {
            var data = new OrderVipBus().GetOrderVipByIdUser(id);
            return data;
        }
        #endregion

        #region LyricsMusic
        public LyricsMusicDTO GetLyricByIdMusic(int id)
        {
            var data = new LyricsMusicBus().GetLyricByIdMusic(id);
            return data;
        }
        public LyricsMusicDTO GetLyricById(int id)
        {
            var data = new LyricsMusicBus().GetLyricById(id);
            return data;
        }
        public bool CreateLyrics(LyricsMusic lyricsMusic)
        {
            if (new LyricsMusicBus().Create(lyricsMusic))
            {
                return true;
            }
            return false;
        }
        public bool UpdateLyrics(LyricsMusic lyricsMusic)
        {
            if (new LyricsMusicBus().Update(lyricsMusic))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region QualityMusic
        public QualityMusicDTO GetQualityMusicById(int id)
        {
            return new QualityMusicBus().GetQualityMusicById(id);
        }
        public IEnumerable<QualityMusicDTO> GetFileByIdMusic(int id)
        {
            return new QualityMusicBus().GetFileByIdMusic(id);
        }
        public IEnumerable<QualityMusicDTO> GetAllQM()
        {
            return new QualityMusicBus().GetAllQM();
        }
        public bool CreateQualityMusic(QualityMusicDTO qualityMusicDTO)
        {
            if (new QualityMusicBus().CreateQualityMusic(qualityMusicDTO))
            {
                return true;
            }
            return false;
        }
        public bool UpdateFile(QualityMusicDTO qualityMusicDTO)
        {
            if (new QualityMusicBus().UpdateFile(qualityMusicDTO))
            {
                return true;
            }
            return false;
        }
        public bool UpdateQualityMusic(QualityMusicDTO qualityMusicDTO)
        {
            if (new QualityMusicBus().UpdateQualityMusic(qualityMusicDTO))
            {
                return true;
            }
            return false;
        }
        public bool DeleteQualityMusic(int id)
        {
            if (new QualityMusicBus().DeleteQualityMusic(id))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Rank

        public void CreateNewRank(RankDTO rank)
        {
            new RankBus().CreateNewRank(rank);
        }


        public IEnumerable<RankDTO> GetAllRank()
        {
            return new RankBus().GetAllRank();
        }

        public void DeleteRank(int id)
        {
            new RankBus().DeleteRank(id);
        }

        public RankDTO GetRankById(int id)
        {
            return new RankBus().GetRankById(id);
        }


        public List<RankDTO> GetListRankThisWeek()
        {
            return  new RankBus().GetListRankThisWeek();
        }

        public void UpdateNewRank(RankDTO rank)
        {
            new RankBus().UpdateRank(rank);
        }

        public IEnumerable<RankDTO> GetAllThisWeekRank()
        {
            return new RankBus().GetAllThisWeekRank();
        }

        public List<RankMusicDTO> RankMusicOld(int id)
        {
            return new RankBus().RankMusicByRankId(id);
        }
        #endregion

        #region PLaylistMusic
        public IEnumerable<PlaylistMusicDTO> GetMusicByIdPlaylist(int id)
        {
            var data = new PlaylistMusicBus().GetMusicByIdPlaylist(id);
            return data;
        }
        public bool CreatePlaylistMusic(PlaylistMusic playlistMusic)
        {
            if (new PlaylistMusicBus().CreatePlaylistMusic(playlistMusic))
            {
                return true;
            }
            return false;
        }
        public bool DeletePlaylistMusic(int id)
        {
            if (new PlaylistMusicBus().DeletePlaylistMusic(id))
            {
                return true;
            }
            return false;
        }
        #endregion




        public List<OrderVipDTO> GetAllOrderVip()
        {
          return new OrderVipBus().GetAllOrderVip();
        }
    }
}