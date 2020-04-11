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
        public ActionResult Create(PartnerDTO partner)
        {
            var data = ApiService.CreatePartner(partner);
            if (data != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult Update(PartnerDTO partner)
        {
            var data = ApiService.UpdatePartner(partner);
            if (data != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit", new { id = partner.ID });
        }
        public ActionResult Delete(int id)
        {
            ApiService.DeletePartner(id);
            return RedirectToAction("Index");
        }

    }
}