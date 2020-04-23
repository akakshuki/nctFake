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
            ViewBag.getMusicByIdCate = ApiService.GetAllMusic().Where(s=>s.CategoryId == id && s.SongOrMV == true).ToList();
            ViewBag.GetSinger = ApiService.GetAllMusic();
            return View();
        }
        public ActionResult IndexMV(int id)
        {
            ViewBag.getMusicByIdCate = ApiService.GetAllMusic().Where(s => s.CategoryId == id && s.SongOrMV == false).ToList();
            ViewBag.GetSinger = ApiService.GetAllMusic();
            return View();
        }
    }
}