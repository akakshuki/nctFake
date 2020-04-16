using AppAdmin.Models.Service;
using ModelViews.DTOs;
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
            ViewBag.getListQualityMusic = ApiService.GetFileByIdMusic(id);
            return View();
        }


        public JsonResult DownLoadFile(int qualityId)
        {
            var data = ApiService.GetQualityMusicById(qualityId);

            var linkFile = data.LinkFile;

            return Json(new
            {
                data = linkFile
            }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult UpdateMusicView(MusicDTO music)
        {
            var data = ApiService.UpdateMusicView(music);
            if (data!= null)
            {
                return RedirectToAction("Index", new { id = music.ID });
            }
            return RedirectToAction("Index",new { id = music.ID });

        }
    }
}