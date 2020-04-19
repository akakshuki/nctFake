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
            var data = db.QualityMusics.Where(s => s.MusicID == id && s.QualityID == 1 || s.QualityID ==3).ToList();
            return data;
        }
        //lay song file 120kbps
        public QualityMusic GetQualityMusicByIdMusic(int id)
        {
            var data = db.QualityMusics.SingleOrDefault(s => s.MusicID == id && s.QualityID == 1 ) ?? null;
            return data;
        }
        //lay mv file 360mp
        public QualityMusic GetQualityMusicByIdMusicMV(int id)
        {
            var data = db.QualityMusics.SingleOrDefault(s => s.MusicID == id && s.QualityID == 3) ?? null;
            return data;
        }
        //getFileByIdMusic
        public QualityMusic GetLinkFileByIdMusic(int id)
        {
            var data = db.QualityMusics.SingleOrDefault(s => s.MusicID == id);
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
        //update Approved
        public bool UpdateFile(QualityMusic qualityMusic)
        {
            var data = db.QualityMusics.SingleOrDefault(s => s.ID == qualityMusic.ID);
            data.QMusicApproved = qualityMusic.QMusicApproved;
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
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