using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Areas.Client.Controllers
{
    public class PayPalController : Controller
    {
        // GET: Client/PayPal
        public ActionResult Index()
        {
            return View();
        }
    }
}