using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViews.DTOs
{
    public class OrderVipDTO
    {

        public int ID { get; set; }
        public int UserID { get; set; }
        public int? PVipID { get; set; }
        public int PaymentID { get; set; }
        public int? OrdPrice { get; set; }
        public DateTime OrdDayCreate { get; set; }

        public UserDTO UserDto { get; set; }
        public PackageVipDTO PackageVipDto { get; set; }
        public PaymentDTO PaymentDto { get; set; }
    }
}
