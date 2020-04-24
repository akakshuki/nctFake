using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelViews.DTOs
{
    public class PartnerDTO
    {
        public int ID { get; set; }
        public string PartnerName { get; set; }
        public string PartnerImage { get; set; }
        public HttpPostedFileBase FileImage { get; set; }
        public string LinkImage { get; set; }
        public string PartnerLink { get; set; }
        public bool PartnerActive { get; set; }
        public DateTime PartnerDayCreate { get; set; }
    }
}