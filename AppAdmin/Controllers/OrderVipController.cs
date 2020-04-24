using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppAdmin.Models.Service;

namespace AppAdmin.Controllers
{
    public class OrderVipController : Controller
    {
        // GET: OrderVip
        public ActionResult Index()
        {
            ViewBag.ListOrderVip = ApiService.GetAllListOrderVip();
            return View();
        }
    }
}
