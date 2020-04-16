using AppAdmin.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Areas.Client.Controllers
{
    public class HomeController : Controller
    {
        // GET: Client/Home
        public ActionResult Index()
        {
            ViewBag.RandomTheoChuDe = ApiService.GetAllCateCon().Where(s => s.ID_root != null).Distinct().OrderBy(s=> Guid.NewGuid()).Take(5).ToList();
            ViewBag.GetPartner = ApiService.GetAllPartner();
            ViewBag.GetSinger = ApiService.GetAllMusic();
            ViewBag.GetTop10SongNew = ApiService.GetAllMusic().Where(s=> s.SongOrMV == true).OrderByDescending(s=>s.MusicDayCreate).Take(10).ToList();
            ViewBag.GetTop10MVNew = ApiService.GetAllMusic().Where(s => s.SongOrMV == false).OrderByDescending(s => s.MusicDayCreate).Take(10).ToList();
            return View();
        }
        public ActionResult NavigationMenu()
        {
            ViewBag.getCate = ApiService.GetAllCate();
            ViewBag.getSubCate = ApiService.GetAllCateCon().Where(s => s.ID_root != null).ToList();
            ViewBag.getTheoChuDe = ApiService.GetAllCateCon().Where(s=>s.ID_root != null).ToList();
            return PartialView();
        }
    }
}