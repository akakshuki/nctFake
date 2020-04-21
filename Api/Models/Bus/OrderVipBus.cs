using Api.Models.Dao;
using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.Bus
{
    public class OrderVipBus
    {
        public IEnumerable<OrderVipDTO> GetOrderVipByIdUser(int id)
        {
            var data = new OrderVipDao().GetOrderVipByIdUser(id).OrderByDescending(s => s.OrdDayCreate).Select(s => new OrderVipDTO 
            {
                ID = s.ID,
                UserID = s.UserID,
                PVipID = s.PVipID,
                PaymentID = s.PaymentID,
                OrdPrice = s.OrdPrice,
                OrdDayCreate = s.OrdDayCreate,
                PackageVipDto = new PackageVipDTO()
                {
                    ID = s.PackageVip.ID,
                    PVipName = s.PackageVip.PVipName
                }       ,
                PaymentDto = new PaymentDTO()
                {
                    ID = s.Payment.ID,
                    PaymentName = s.Payment.PaymentName
                }
            });
            return data;
        }

        public List<OrderVipDTO> GetAllOrderVip()
        {
            var data = new OrderVipDao().GetAll().OrderByDescending(s => s.OrdDayCreate).Select(s => new OrderVipDTO
            {
                ID = s.ID,
                UserID = s.UserID,
                PVipID = s.PVipID,
                PaymentID = s.PaymentID,
                OrdPrice = s.OrdPrice,
                OrdDayCreate = s.OrdDayCreate,
                UserDto = new UserBus().GetUserDtoById(s.UserID),
                PackageVipDto = new PackageVipDTO()
                {
                    ID = s.PackageVip.ID,
                    PVipName = s.PackageVip.PVipName
                },
                PaymentDto = new PaymentDTO()
                {
                    ID = s.Payment.ID,
                    PaymentName = s.Payment.PaymentName
                }
            });
            return data.ToList();
        }
    }
}