using Api.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.Dao
{
    public class OrderVipDao
    {
        private ProjectNCTEntities db = null;

        public OrderVipDao()
        {
            db = new ProjectNCTEntities();
        }
        public List<OrderVip> GetOrderVipByIdUser(int id)
        {
            var data = db.OrderVips.Where(s => s.UserID == id).ToList();
            return data;
        }

        public IEnumerable<OrderVip> GetAll()
        {
            return db.OrderVips;
        }
    }
}