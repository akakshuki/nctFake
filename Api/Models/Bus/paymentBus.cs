using Api.Models.Dao;
using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;

namespace Api.Models.Bus
{
    public class PaymentBus
    {
        public bool CreateNewPayment(PaymentDTO payment)
        {
            try
            {
               new PaymentDao().Create(new Payment()
                {
                    PaymentName = payment.PaymentName
                });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeletePayment(int id)
        {
            try
            {
                new PaymentDao().Delete(id);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdatePayment(PaymentDTO payment)
        {
            try
            {
                new PaymentDao().Update(new Payment()
                {
                    PaymentName = payment.PaymentName
                });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public IEnumerable<PaymentDTO> GetAllPayment()
        {
            var list = new List<PaymentDTO>();
            foreach (var payment in new PaymentDao().GetAll())
            {
                var res = new PaymentDTO()
                {
                    ID = payment.ID,
                    PaymentName = payment.PaymentName
                };
                list.Add(res);
            }

            return list;
        }

        public PaymentDTO GetPaynemtById(int id)
        {
            try
            {
                var data = new PaymentDao().GetById(id);
                return new PaymentDTO()
                {
                    ID = data.ID,
                    PaymentName = data.PaymentName
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}