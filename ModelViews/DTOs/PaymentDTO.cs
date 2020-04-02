using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelViews.DTOs {
    public class PaymentDTO 
    {
        public int ID { get; set; }
        public string PaymentName { get; set; }

        public List<PackageVipDTO> PackageVipDtos { get; set; }

    }
}