using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppAdmin.Models.Service;
using ModelViews.DTOs;

namespace AppAdmin.Controllers
{
    public class QualityController : Controller
    {
        // GET: Quality
        public ActionResult Index()
        {
            ViewBag.QualityList = ApiService.GetAllQuality();
            return View();
        }

        public ActionResult Delete(int id)
        {
            ApiService.DeleteQuality(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult GetById(int id)
        {
            var data = ApiService.GetQualityById(id);
            return Json(new
            {
                data = data
            },JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(QualityDTO quality)
        {
            if (quality.ID == 0)
            {
                ApiService.CreateQuality(quality);
            }
            else
            {
                ApiService.UpdateQuality(quality);
            }


            return RedirectToAction("Index");
        }

    }
}
