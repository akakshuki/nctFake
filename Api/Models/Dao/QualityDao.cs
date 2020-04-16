using Api.Models.EF;
using ModelViews.DTOs;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Api.Models.Dao
{
    public class QualityDao
    {
        private ProjectNCTEntities db = null;

        public QualityDao()
        {
            db = new ProjectNCTEntities();
        }

        //create
        public Quality Create(Quality quality)
        {
            db.Qualities.Add(quality);
            if (db.SaveChanges() > 0)
            {
                return quality;
            };
            return null;
        }

        //delete
        public void Delete(int id)
        {
            var data = db.Qualities.Find(id);
            if (data != null)
            {
                db.Qualities.Remove(data);
                db.SaveChanges();
            }
        }

        public void Unactive(int id)
        {
        }

        //update
        public void Update(Quality quality)
        {
            db.Entry(quality).State = EntityState.Modified;
            db.SaveChanges();
        }

        //select by id
        public Quality FindById(int id)
        {
            return db.Qualities.Find(id);
        }

        //get All list
        public IEnumerable<Quality> GetAll()
        {
            return db.Qualities.ToList();
        }

        //get paging
        public IEnumerable<Quality> GetPageQuality(Pagination page)
        {
            var data = db.Qualities.ToList().Skip(page.Index * page.Size).Take(page.Size);

            return data;
        }

    }
}