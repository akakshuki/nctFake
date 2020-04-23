using Api.Models.EF;
using ModelViews.DTOs;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Api.Models.Dao
{
    public class MusicDao
    {
        private ProjectNCTEntities db = null;

        public MusicDao()
        {
            db = new ProjectNCTEntities();
        }

        //create
        public Music Create(Music music)
        {
            db.Musics.Add(music);
            if (db.SaveChanges() > 0)
            {
                return music;
            };
            return null;
        }
        //delete file lien quan nhac
        #region deletefiletuiupload 
        public bool DeleteLQ(int id)
        {
            var data = db.Musics.Find(id);
            var lsQualityMusic = new QualityMusicDao().GetFileByIdMusic(data.ID);
            var lsSinger = new SingerMusicDao().GetSMByID(data.ID);
            foreach (var qualityMusic in lsQualityMusic)
            {
                db.QualityMusics.Remove(db.QualityMusics.Find(qualityMusic.ID));
                db.SaveChanges();
            }
            foreach (var singer in lsSinger)
            {
                db.SingerMusics.Remove(db.SingerMusics.Find(singer.ID));
                db.SaveChanges();
            }
            return DeleteMusicLQ(id) == true ? true : false;
        }
        private bool DeleteMusicLQ(int id)
        {
            var data = db.Musics.SingleOrDefault(s => s.ID == id);
            db.Musics.Remove(data);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        #endregion


        //delete
        public void Delete(int id)
        {
            var data = db.Musics.Find(id);
            if (data != null)
            {
                db.Musics.Remove(data);
                db.SaveChanges();
            }
        }

        public void Unactive(int id)
        {
        }
        //update MusicView
        public int UpdateView(int id)
        {
            var data = db.Musics.Find(id);
            var itemView = data.MusicView + 1;
            data.MusicView = itemView;
            return db.SaveChanges() > 0 ? itemView : 0;
        }
        //update
        public void Update(Music music)
        {
            db.Entry(music).State = EntityState.Modified;
            db.SaveChanges();
        }

        //select by id
        public Music FindById(int id)
        {
            return db.Musics.Find(id);
        }

        //get All list
        public IEnumerable<Music> GetAll()
        {
            return db.Musics.ToList();
        }

        //get paging
        public IEnumerable<Music> GetPageMusic(Pagination page)
        {
            var data = db.Musics.OrderBy(x => x.MusicDayCreate)
                .ToList()
                .Skip(page.Index * page.Size)
                .Take(page.Size);
            return data;
        }

        //getMusicByIdUser
        public List<Music> GetMusicByIdUser(int id)
        {
            var data = db.Musics.Where(s => s.UserID == id).ToList();
            return data;
        }

    }
}