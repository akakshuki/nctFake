using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Api.Models.EF;

namespace Api.Models.Dao
{
    public class RankMusicDao
    {
        
            private ProjectNCTEntities db = null;

            public RankMusicDao()
            {
                db = new ProjectNCTEntities();
            }

            //create
            public RankMusic Create(RankMusic rank)
            {
                db.RankMusics.Add(rank);
                if (db.SaveChanges() > 0)
                {
                    return rank;
                }

                return null;
            }

            //delete
            public void Delete(int id)
            {
                var data = db.RankMusics.Find(id);
                if (data != null)
                {
                    db.RankMusics.Remove(data);
                    db.SaveChanges();
                }
            }

            public void Unactive(int id)
            {
            }

            //update
            public void Update(RankMusic rank)
            {
                db.Entry(rank).State = EntityState.Modified;
                db.SaveChanges();
            }

            public List<RankMusic> GetAll()
            {
                return db.RankMusics.ToList();
            }

            public RankMusic GetById(int id)
            {
                return db.RankMusics.Find(id);
            }
        
    }
}