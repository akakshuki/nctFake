using AppAdmin.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Areas.Client.Controllers
{
    public class listMusicByIdCateController : Controller
    {
        // GET: Client/listMusicByIdCate
        public ActionResult Index(int id)
        {
            ViewBag.getMusicByIdCate = ApiService.GetAllMusic().Where(s=>s.CategoryId == id).ToList();
            ViewBag.GetSinger = ApiService.GetAllMusic();
            return View();
        }
    }
}