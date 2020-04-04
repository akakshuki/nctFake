using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelViews.DTOs
{
    public class PackageVipDTO
    {
        public int ID { get; set; }
        public string PVipName { get; set; }
        public int PVipMonths { get; set; }
        public int PVipPrice { get; set; }


        public List<OrderVipDTO> OrderVipDtos { get; set; }

    }
}