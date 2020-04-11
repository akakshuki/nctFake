using Api.Models.EF;
using System.Collections.Generic;
using System.Linq;

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

        public Partner GetPartnerById(int id)
        {
            return db.Partners.SingleOrDefault(s => s.ID == id);
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
            var data = db.Partners.SingleOrDefault(s => s.ID == partner.ID);
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
        public bool DeletePartner(int id)
        {
            var data = db.Partners.SingleOrDefault(s => s.ID == id);
            db.Partners.Remove(data);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}