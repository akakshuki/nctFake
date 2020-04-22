using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Api.Models.EF;

namespace Api.Models.Dao
{
    public class HistoryUserDao
    {
        private ProjectNCTEntities db = null;

        public HistoryUserDao()
        {
            db = new ProjectNCTEntities();
        }

        public List<HistoryUser> GetAllHistoryUser()
        {
            return db.HistoryUsers.ToList();
        }

        public HistoryUser GetHistoryUserById(int id)
        {
            return db.HistoryUsers.SingleOrDefault(s => s.ID == id);
        }

        public bool CreateHistoryUser(HistoryUser historyUser)
        {
            db.HistoryUsers.Add(historyUser);
            return db.SaveChanges() > 0;
        }

        public bool UpdatePartner(HistoryUser historyUser)
        {
            db.Entry(historyUser).State = EntityState.Modified;
            db.SaveChanges();
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteHistory(int idUser, int idMusic)
        {
            var data = db.HistoryUsers.Where(x=>x.MusicID== idMusic && x.UserID == idUser);
            foreach (var historyUser in data)
            {
                db.HistoryUsers.Remove(historyUser);
            }
            return db.SaveChanges() > 0;
        }

        public bool DeleteAllHistoryUser(int idUser)
        {
            var lis = db.HistoryUsers.Where(x => x.UserID == idUser);
            foreach (var historyUser in lis)
            {
                db.HistoryUsers.Remove(historyUser);
            }
            return db.SaveChanges() > 0;
        }
    }
}