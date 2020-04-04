using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Api.Models.EF;
using ModelViews.DTOs;

namespace Api.Models.Dao
{
    public class PaymentDao
    {
        private ProjectNCTEntities db = null;

        public PaymentDao()
        {
            db = new ProjectNCTEntities();
        }

        //create 
        public Payment Create(Payment payment)
        {
            db.Payments.Add(payment);
            if (db.SaveChanges() > 0)
            {
                return payment;
            }

            return null;

        }

        //delete
        public void Delete(int id)
        {
            var data = db.Payments.Find(id);
            if (data != null)
            {
                db.Payments.Remove(data);
                db.SaveChanges();
            }
        }

        public void Unactive(int id)
        {

        }

        //update
        public void Update(Payment payment)
        {
            db.Entry(payment).State = EntityState.Modified;
            db.SaveChanges();
        }


        public List<Payment> GetAll()
        {
            return db.Payments.ToList();
        }


        public Payment GetById(int id)
        {
            return db.Payments.Find(id);
        }
    }
}