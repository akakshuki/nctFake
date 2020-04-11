using Api.Models.Dao;
using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public Partner GetPartnerById(int id)
        {
            var data = new PartnerDao().GetPartnerById(id);
            return new Partner
            {
                ID = data.ID,
                PartnerActive = data.PartnerActive,
                PartnerImage = data.PartnerImage,
                PartnerLink = data.PartnerLink,
                PartnerName = data.PartnerName
            };
        }

        public bool CreatePartner(PartnerDTO partner)
        {
            string fileName = "";
            if (partner.FileData != null)
            {
                fileName = DateTime.Now.Ticks.ToString();
                string filePath = "~/File/ImageUser/" + Path.GetFileName(fileName + ".jpg");
                File.WriteAllBytes(System.Web.HttpContext.Current.Server.MapPath(filePath), Convert.FromBase64String(partner.FileData));
                fileName = fileName + ".jpg";
            }
            else
            {
                fileName = "default";
            }
            try
            {

                var data = new PartnerDao().CreatePartner(new Partner()
                {
                    PartnerActive = true,
                    PartnerDayCreate = DateTime.Now,
                    PartnerImage = fileName,
                    PartnerLink = partner.PartnerLink,
                    PartnerName = partner.PartnerName
                });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdatePartner(PartnerDTO partner)
        {
            string fileName = "";
            if (partner.FileData != null)
            {
                fileName = DateTime.Now.Ticks.ToString();
                string filePath = "~/File/ImageUser/" + Path.GetFileName(fileName + ".jpg");
                File.WriteAllBytes(System.Web.HttpContext.Current.Server.MapPath(filePath), Convert.FromBase64String(partner.FileData));
                fileName = fileName + ".jpg";
            }
            else
            {
                fileName = "default";
            }
            try
            {

                var data = new PartnerDao().UpdatePartner(new Partner()
                {
                    ID = partner.ID,
                    PartnerActive = true,
                    PartnerDayCreate = DateTime.Now,
                    PartnerImage = fileName,
                    PartnerLink = partner.PartnerLink,
                    PartnerName = partner.PartnerName
                });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public bool DeletePartner(int id)
        {
            if (new PartnerDao().DeletePartner(id))
            {
                return true;
            }
            return false;
        }
    }
}