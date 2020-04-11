using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Api.Models.EF;

namespace Api.Models.Dao
{
    public class SingerMusicDao
    {
        private ProjectNCTEntities db = null;

        public SingerMusicDao()
        {
            db = new ProjectNCTEntities();
        }

        //create
        public SingerMusic Create(SingerMusic singerMusic)
        {
            db.SingerMusics.Add(singerMusic);
            if (db.SaveChanges() > 0)
            {
                return singerMusic;
            }

            return null;
        }

        //delete
        public void Delete(int id)
        {
            var data = db.SingerMusics.Find(id);
            if (data != null)
            {
                db.SingerMusics.Remove(data);
                db.SaveChanges();
            }
        }

        public void Unactive(int id)
        {
        }

        //update
        public void Update(SingerMusic singerMusic)
        {
            db.Entry(singerMusic).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<SingerMusic> GetAll()
        {
            return db.SingerMusics.ToList();
        }

        public SingerMusic GetById(int id)
        {
            return db.SingerMusics.Find(id);
        }
    }
}