using AppAdmin.Models.Service;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Controllers
{
    public class PartnerController : Controller
    {
        private string path = "";
        public PartnerController()
        {
            path = "~/File/ImagePartner/";
        }
        // GET: Partner
        public ActionResult Index()
        {
            ViewBag.ListPartner = ApiService.GetAllPartner();
            return View();
        }
        public ActionResult Edit(int id)
        {
            var data = ApiService.GetPartnerById(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Create(PartnerDTO partner)
        {
            try
            {
                if (partner.FileImage != null)
                {
                    partner.PartnerImage = DateTime.Now.Ticks + partner.PartnerImage + ".png";
                    partner.FileImage.SaveAs(Server.MapPath(path + partner.PartnerImage));
                    partner.FileImage = null;
                }
                else
                {
                    partner.PartnerImage = "default.png";
                }
                var data = ApiService.CreatePartner(partner);
                if (data != null)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index");           
            }                  
        }
        [HttpPost]
        public ActionResult Update(PartnerDTO partner)
        {
            try
            {
                //get Image have exist
                var currentFileName = ApiService.GetPartnerById(partner.ID).PartnerImage;
                //check name have deafault if exist ==> dont delete
                if (currentFileName == "default.png")
                {
                    if (partner.FileImage != null)
                    {
                        partner.PartnerImage = DateTime.Now.Ticks + partner.PartnerImage + ".png";
                        partner.FileImage.SaveAs(Server.MapPath(path + partner.PartnerImage));
                        partner.FileImage = null;
                    }
                    else
                    {
                        partner.PartnerImage = "default.png";
                    }
                }
                else
                {
             


                    if (partner.FileImage != null)
                    {
                        //delete file
                        var filePath = Server.MapPath(path + currentFileName);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        partner.PartnerImage = DateTime.Now.Ticks + partner.PartnerImage + ".png";
                        partner.FileImage.SaveAs(Server.MapPath(path + partner.PartnerImage));
                        partner.FileImage = null;
                    }
                    else
                    {
                        partner.PartnerImage = currentFileName;
                    }
                }
                var data = ApiService.UpdatePartner(partner);
                if (data != null)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Edit", new { id = partner.ID });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Edit", new { id = partner.ID });
            }

        }
        public ActionResult Delete(int id)
        {
            ApiService.DeletePartner(id);
            return RedirectToAction("Index");
        }

    }
}