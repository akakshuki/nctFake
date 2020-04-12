using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Api.Models.EF;
using ModelViews.DTOs;

namespace Api.Models.Dao
{
    public class RankDao
    {
        private ProjectNCTEntities db = null;

        public RankDao()
        {
            db = new ProjectNCTEntities();
        }

        //create
        public Rank Create(Rank rank)
        {
            db.Ranks.Add(rank);
            if (db.SaveChanges() > 0)
            {
                return rank;
            }

            return null;
        }

        //delete
        public void Delete(int id)
        {
            var data = db.Ranks.Find(id);
            if (data != null)
            {
                db.Ranks.Remove(data);
                db.SaveChanges();
            }
        }

        public void Unactive(int id)
        {
        }

        //update
        public void Update(Rank rank)
        {
            var data = db.Ranks.SingleOrDefault(x => x.ID == rank.ID);
            if (data != null)
            {
                data.RMusicName = rank.RMusicName;
                data.CateID = rank.CateID;
                data.SongOrMusic = rank.SongOrMusic;
            }

            db.SaveChanges();
        }

        public List<Rank> GetAll()
        {
            return db.Ranks.ToList();
        }

        public Rank GetById(int id)
        {
            return db.Ranks.Find(id);
        }

        public void CheckOutDay(RankDTO rankDto)
        {
            var data = db.Ranks.SingleOrDefault(x => x.ID == rankDto.ID);
            if (data != null)
            {
                data.RMusicEnd = rankDto.RMusicEnd;
            }
            db.SaveChanges();
        }
    }
}