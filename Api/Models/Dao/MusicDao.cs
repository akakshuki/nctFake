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
    }
}