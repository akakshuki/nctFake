using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Areas.Client.Controllers
{
    public class AccountUserController : Controller
    {
        // GET: Client/AccountUser
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AccountUser()
        {
            return View();
        }
    }
}