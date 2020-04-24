using AppAdmin.Common;
using AppAdmin.Models.Service;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Controllers
{
    public class LyricsMusicController : Controller
    {
        // GET: LyricsMusic
        public ActionResult Index(int id)
        {
            var data = ApiService.GetLyricByIdMusic(id);
            if (data == null)
            {
                return RedirectToAction("NullView");
            }
            return View(data);
        }
        public ActionResult Edit(int id)
        {

            ViewBag.Music = ApiService.GetAllMusic();
            var data = ApiService.GetLyricById(id);
            return View(data);
        }
        public ActionResult ViewCreate(int id)
        {
            ViewBag.getMusicId = ApiService.GetMusicById(id);
            ViewBag.Music = ApiService.GetAllMusic();
            return View();
        }
        public ActionResult Create(LyricsMusicDTO lyricsMusic)
        {
            //var UserId = (UserDTO)Session[CommonConstants.USER_SESSION];
            //lyricsMusic.UserID = UserId.ID;
            lyricsMusic.UserID = 31;
            var data = ApiService.CreateLyrics(lyricsMusic);
            if (data != null)
            {
                return RedirectToAction("Index","Music");
            }
            return RedirectToAction("ViewCreate");
        }
        public ActionResult Update(LyricsMusicDTO lyricsMusic)
        {
            //var UserId = (UserDTO)Session[CommonConstants.USER_SESSION];
            //lyricsMusic.UserID = UserId.ID;
            lyricsMusic.UserID = 31;
            var data = ApiService.UpdateLyrics(lyricsMusic);
            if (data != null)
            {
                return RedirectToAction("Index", "LyricsMusic", new { id = lyricsMusic.MusicID });
            }
            return RedirectToAction("Edit",new { id =lyricsMusic.ID });
        }
        public ActionResult NullView()
        {
            return View();
        }

    }
}