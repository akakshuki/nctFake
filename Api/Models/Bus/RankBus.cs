using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Models.Dao;
using Api.Models.EF;
using ModelViews.DTOs;

namespace Api.Models.Bus
{
    public class RankBus
    {
        public void CreateNewRank(RankDTO rank)
        {
            new RankDao().Create(new Rank()
            {
                RMusicName = rank.RMusicName,
                RMusicStart = rank.RMusicStart,
                CateID = rank.CateID,
                RMusicEnd = rank.RMusicEnd,
                SongOrMusic = rank.SongOrMusic,
                OldWeekRankId = rank.OldWeekRankId
            });


            if (rank.OldWeekRankId != 0)
            {
                var data = new RankBus().GetListRankThisWeek().SingleOrDefault(x => x.ID == rank.OldWeekRankId);
                if (data != null)
                {
                    foreach (var music in data.MusicDtos)
                    {
                        new RankMusicDao().Create(new RankMusic()
                        {
                            MusicID = music.ID,
                            RankID = data.ID,
                            RMusicGrade = music.GradeRank
                        });
                    }
                }

                new RankDao().CheckOutDay(new RankDTO()
                {
                    ID = rank.OldWeekRankId,
                    RMusicEnd = DateTime.Now
                });

            }
        }

        public IEnumerable<RankDTO> GetAllRank()
        {
            var list = new RankDao().GetAll().Select(x => new RankDTO()
            {

                RMusicName = x.RMusicName,
                SongOrMusic = x.SongOrMusic,
                RMusicEnd = x.RMusicEnd,
                RMusicStart = x.RMusicStart,
                CateID = x.CateID,
                ID = x.ID,
                OldWeekRankId = x.OldWeekRankId,

            });

            var rankDtos = list.ToList();
            foreach (var rankDto in rankDtos)
            {
                var data = new CategoryDao().GetCateById(rankDto.CateID);
                rankDto.CategoryDto = new CategoryDTO()
                {
                    ID = data.ID,
                    CateName = data.CateName,
                };
            }
            return rankDtos;
        }

        public IEnumerable<RankDTO> GetAllThisWeekRank()
        {
            return new RankDao().GetAll().Where(x => x.RMusicEnd > DateTime.Now).Select(x => new RankDTO()
            {

                RMusicName = x.RMusicName,
                SongOrMusic = x.SongOrMusic,
                RMusicEnd = x.RMusicEnd,
                RMusicStart = x.RMusicStart,
                CateID = x.CateID,
                ID = x.ID,
                OldWeekRankId = x.OldWeekRankId,
            });
        }


        public RankDTO GetRankById(int id)
        {
            var data = new RankDao().GetById(id);
            return new RankDTO()
            {
                ID = data.ID,
                CateID = data.CateID,
                RMusicStart = data.RMusicStart,
                RMusicEnd = data.RMusicEnd,
                RMusicName = data.RMusicName,
                SongOrMusic = data.SongOrMusic
            };
        }

        public void DeleteRank(int id)
        {
            new RankDao().Delete(id);
        }




        public List<RankDTO> GetListRankThisWeek()
        {
            int currentWeek = (DateTime.Now.DayOfYear / 7) + 1;
            var data = new RankDao().GetAll().Where(x => x.RMusicEnd >= DateTime.Now).Select(x => new RankDTO()
            {
                ID = x.ID,
                CateID = x.CateID,
                RMusicStart = x.RMusicStart,
                RMusicEnd = x.RMusicEnd,
                RMusicName = x.RMusicName,
                SongOrMusic = x.SongOrMusic,
                OldWeekRankId = x.OldWeekRankId
            }).ToList();

            foreach (var rankDto in data)
            {
                rankDto.CategoryDto = new CategoryBus()
                    .GetAllListCategories()
                    .SingleOrDefault(x => x.ID == rankDto.CateID);
                var musicdata = new MusicBus()
                      .GetListMusicAll()
                      .Where(x => x.CategoryDto.ID_root == rankDto.CateID && x.SongOrMV == rankDto.SongOrMusic)
                      .OrderByDescending(x => x.MusicView)
                      .Take(10)
                      .ToList();
                foreach (var musicDto in musicdata)
                {
                    musicDto.GradeRank = musicdata.IndexOf(musicDto) + 1;
                }
                rankDto.MusicDtos = musicdata;
            }

            return data;
        }

        public void UpdateRank(RankDTO rank)
        {
            new RankDao().Update(new Rank()
            {
                ID = rank.ID,
                RMusicName = rank.RMusicName,
                //RMusicStart = rank.RMusicStart,
                CateID = rank.CateID,
                //RMusicEnd = rank.RMusicEnd,
                SongOrMusic = rank.SongOrMusic
            });
        }


        public List<RankMusicDTO> RankMusicByRankId(int id)
        {
            var list = new RankMusicDao().GetAll().Where(x => x.RankID == id).Select(x => new RankMusicDTO()
            {
                ID = x.ID,
                MusicID = x.MusicID,
                RankID = x.RankID,
                MusicDto = new MusicBus().GetListMusicAll().SingleOrDefault(k => k.ID == x.MusicID),
                RMusicGrade = x.RMusicGrade,
                RankDto = new RankBus().GetAllRank().SingleOrDefault(k => k.ID == x.RankID)
            });
            return list.ToList();
        }
    }
}