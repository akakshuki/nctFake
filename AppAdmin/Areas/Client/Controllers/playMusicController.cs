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
            ViewBag.getMusicById = ApiService.GetMusicById(id);
            ViewBag.getLyrics = ApiService.GetLyricByIdMusic(id);
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
    }
}