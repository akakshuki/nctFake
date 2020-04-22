using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Areas.Client.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Client/Error
        public ActionResult NotFound()
        {
            return View();
        }
    }
}