using AppAdmin.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Areas.Client.Controllers
{
    public class playMusicController : Controller
    {
        // GET: Client/playMusic
        public ActionResult Index(int id)
        {
          
            ViewBag.GetSinger = ApiService.GetAllMusic();
            ViewBag.getMusicById = ApiService.GetMusicById(id);
            ViewBag.getLyrics = ApiService.GetLyricByIdMusic(id);
            ViewBag.getMusicRandom = ApiService.GetAllMusic().Distinct().OrderBy(s=> Guid.NewGuid()).Take(5).ToList();
            return View();
        }
    }
}