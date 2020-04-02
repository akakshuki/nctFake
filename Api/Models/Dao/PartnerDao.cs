using Api.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.Dao
{
    public class PartnerDao
    {
        private ProjectNCTEntities db = null;
        public PartnerDao()
        {
            db = new ProjectNCTEntities();
        }
        public List<Partner> GetAllPartner()
        {
            return db.Partners.ToList();
        }
        public bool CreatePartner(Partner partner)
        {
            db.Partners.Add(partner);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdatePartner(Partner partner)
        {
            var data = db.Partners.SingleOrDefault(s=> s.ID == partner.ID);
            data.PartnerName = partner.PartnerName;
            data.PartnerLink = partner.PartnerLink;
            data.PartnerImage = partner.PartnerImage;
            data.PartnerActive = partner.PartnerActive;
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}