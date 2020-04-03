using Api.Models.Dao;
using Api.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.Bus
{
    public class PartnerBus
    {
        public IEnumerable<Partner> GetAllPartner()
        {
            var data = new PartnerDao().GetAllPartner().Select(s => new Partner 
            {
                ID = s.ID,
                PartnerActive = s.PartnerActive,
                PartnerDayCreate = s.PartnerDayCreate,
                PartnerImage = s.PartnerImage,
                PartnerLink = s.PartnerLink,
                PartnerName = s.PartnerName
            });
            return data;
        }
        public bool CreatePartner(Partner partner)
        {
            if (new PartnerDao().CreatePartner(partner))
            {
                return true;
            }
            return false;
        }
        public bool UpdatePartner(Partner partner)
        {
            if (new PartnerDao().UpdatePartner(partner))
            {
                return true;
            }
            return false;
        }
    }
}