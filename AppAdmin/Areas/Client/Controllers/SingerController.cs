using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppAdmin.Areas.Client.Models.ServiceClient;
using AppAdmin.Models.Service;

namespace AppAdmin.Areas.Client.Controllers
{
    public class SingerController : Controller
    {
        // GET: Client/Singer
        

        public  ActionResult Index(int id)
        {
            ViewBag.SingerData = ApiService.GetAllSinger().SingleOrDefault(x => x.ID == id);
            ViewBag.ListMusic = ApiService.GetAllMusic().Where(x => x.SingerMusicDtOs.Any(k => k.SingerID == id)).ToList();
            ViewBag.PlayListMusic = ApiService.GetAllPlaylistMusic()
                .Where(x => x.MusicDto.SingerMusicDtOs.Any(k => k.SingerID == id)).ToList();

            return View();
        }
    }
}