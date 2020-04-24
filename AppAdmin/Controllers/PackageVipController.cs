        using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppAdmin.Models.Service;
using ModelViews.DTOs;

namespace AppAdmin.Controllers
{
    public class PackageVipController : Controller
    {
        // GET: PackageVip
        public ActionResult Index()
        {
            ViewBag.Payment = ApiService.GetAllPayment();
            ViewBag.PackageVip = ApiService.GetAllPackageVip(); 
            return View();
        }
        
        // GET: PackageVip/Create
        public ActionResult CreatePayment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePayment(PaymentDTO payment)
        {
            var res = ApiService.CreatePayment(payment);
            if (!res) return RedirectToAction("CreatePayment");
            ViewBag.Payment = ApiService.GetAllPayment();
            ViewBag.PackageVip = ApiService.GetAllPackageVip();
            return RedirectToAction("Index");
        }

        public ActionResult CreatePackageVip()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePackageVip(PackageVipDTO packageVip)
        {
            var res = ApiService.CreatePackageVip(packageVip);
            if (!res) return RedirectToAction("CreatePackageVip");
            ViewBag.Payment = ApiService.GetAllPayment();
            ViewBag.PackageVip = ApiService.GetAllPackageVip();
            return RedirectToAction("Index");
        }

        // GET: PackageVip/Edit/5
        [HttpGet]
        public ActionResult EditPackageVip(int id)
        {
            var data = ApiService.GetPackageVipById(id);
            return View(data);
        }

        // POST: PackageVip/Edit/5
        [HttpPost]
        public ActionResult EditPackageVip(PackageVipDTO packageVipDto)
        {
            try
            {
                // TODO: Add update logic here
                var res = ApiService.UpdatePackageVip(packageVipDto);
                if (!res) return RedirectToAction("EditPackageVip");
                ViewBag.Payment = ApiService.GetAllPayment();
                ViewBag.PackageVip = ApiService.GetAllPackageVip();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: PackageVip/Delete/5
        public ActionResult DeletePackageVip(int id)
        {
            ApiService.DeletePackageVip(id);
            return RedirectToAction("Index");
        }

        public ActionResult DeletePayment(int id)
        {
            ApiService.DeletePayment(id);
            return RedirectToAction("Index");
        }

    }
}

