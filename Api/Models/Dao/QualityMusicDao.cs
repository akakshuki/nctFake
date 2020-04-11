using Api.Models.EF;
using ModelViews.DTOs;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Api.Models.Dao
{
    public class QualityMusicDao
    {
        private ProjectNCTEntities db = null;

        public QualityMusicDao()
        {
            db = new ProjectNCTEntities();
        }
        //getFileByIdMusic
        public List<QualityMusic> GetFileByIdMusic(int id)
        {
            var data = db.QualityMusics.Where(s => s.MusicID == id).ToList();
            return data;
        }
        //create
        public QualityMusic Create(QualityMusic qualityMusic)
        {
            db.QualityMusics.Add(qualityMusic);
            if (db.SaveChanges() > 0)
            {
                return qualityMusic;
            };
            return null;
        }

        //delete
        public void Delete(int id)
        {
            var data = db.QualityMusics.Find(id);
            if (data != null)
            {
                db.QualityMusics.Remove(data);
                db.SaveChanges();
            }
        }

        public void Unactive(int id)
        {
        }

        //update
        public void Update(QualityMusic qualityMusic)
        {
            db.Entry(qualityMusic).State = EntityState.Modified;
            db.SaveChanges();
        }

        //select by id
        public QualityMusic FindById(int id)
        {
            return db.QualityMusics.Find(id);
        }

        //get All list
        public IEnumerable<QualityMusic> GetAll()
        {
            return db.QualityMusics.ToList();
        }

        //get paging
        public IEnumerable<QualityMusic> GetPageQuality(Pagination page)
        {
            var data = db.QualityMusics.ToList().Skip(page.Index * page.Size).Take(page.Size);
            return data;
        }
    }
}