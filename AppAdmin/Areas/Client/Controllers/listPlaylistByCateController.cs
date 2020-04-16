
using AppAdmin.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Areas.Client.Controllers
{
    public class listPlaylistByCateController : Controller
    {
        // GET: Client/listPlaylistByCate
        public ActionResult Index(int id)
        {
            ViewBag.getListPlaylist = ApiService.GetPlaylistByIdCate(id);
            
            return View();
        }
    }
}