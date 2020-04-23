using AppAdmin.Common;
using AppAdmin.Models.Service;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Areas.Client.Controllers
{
    public class playMusicController : Controller
    {
        // GET: Client/playMusic
        public ActionResult Index(int id)
        {
            Session["SessionUser"]=(UserDTO)Session[CommonConstants.USER_SESSION];
            var UserId = (UserDTO)Session[CommonConstants.USER_SESSION];
            if (UserId == null)
            {
                Session["UserId"] = null;
                ViewBag.getPlaylistByIdUser = null;
            }
            else
            {
                Session["UserId"] = UserId.ID;
                new ApiService().CreateHistory(new HistoryUserDTO()
                {
                    MusicID = id,
                    UserID = UserId.ID
            });
                if (ApiService.GetPlaylistByIdUser(UserId.ID).Count() > 0)
                {
                    ViewBag.getPlaylistByIdUser = ApiService.GetPlaylistByIdUser(UserId.ID);
                }
                else
                {
                    ViewBag.getPlaylistByIdUser = null;
                }
            }
            
                                     
            ViewBag.GetAllMusic = ApiService.GetAllMusic();
            var data = ApiService.GetAllMusic();
            ViewBag.getMusicById = ApiService.GetMusicById(id);
            ViewBag.getLyrics = ApiService.GetLyricByIdMusic(id);
            ViewBag.getMusicRandom = data.Where(s=>s.SongOrMV==true).Distinct().OrderBy(s=> Guid.NewGuid()).Take(5).ToList();
            ViewBag.getMvRandom = data.Where(s=>s.SongOrMV==false).Distinct().OrderBy(s=> Guid.NewGuid()).Take(5).ToList();
            ViewBag.getListQualityMusic = ApiService.GetFileByIdMusic(id);
            ViewBag.getAllPlaylistMusic = ApiService.GetAllPlaylistMusic();
            //lay song file 120kbps
            ViewBag.getQualityMusicByIdMusic = ApiService.GetQualityMusicByIdMusic(id);
            //lay mv file 360mp
            ViewBag.getQualityMusicByIdMusicMv = ApiService.GetQualityMusicByIdMusicMV(id);
            return View();
        }

        public JsonResult AddMusicPlaylist(PlaylistMusicDTO playlistMusicDTO)
        {
            var data = ApiService.CreatePlaylistMusic(playlistMusicDTO);
            if (data!=null)
            {
                return Json(new
                {
                    status = true
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                status = false
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateLyrics(LyricsMusicDTO lyricsMusicDTO)
        {

            var UserId = (UserDTO)Session[CommonConstants.USER_SESSION];

            lyricsMusicDTO.UserID = UserId.ID;

            var data = ApiService.CreateLyrics(lyricsMusicDTO);
            if (data != null)
            {
                TempData["success"] = "Cập nhật lời cho bài hát này thành công";
                return RedirectToAction("Index", "playMusic", new { id = lyricsMusicDTO.MusicID });

            }
            TempData["error"] = "Xảy ra lỗi khi cập nhật lời cho bài hát này";
            return RedirectToAction("Index", "playMusic", new { id = lyricsMusicDTO.MusicID });
        }
        public ActionResult UpdateLyrics(LyricsMusicDTO lyricsMusicDTO)
        {

            var UserId = (UserDTO)Session[CommonConstants.USER_SESSION];

            lyricsMusicDTO.UserID = UserId.ID;

            var data = ApiService.UpdateLyrics(lyricsMusicDTO);
            if (data!=null)
            {
                TempData["success"] = "Cập nhật lời cho bài hát này thành công";
                return RedirectToAction("Index", "playMusic", new { id = lyricsMusicDTO.MusicID });

            }
            TempData["error"] = "Xảy ra lỗi khi cập nhật lời cho bài hát này";
            return RedirectToAction("Index", "playMusic", new { id = lyricsMusicDTO.MusicID });
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


        [HttpGet]
        public JsonResult UpdateView(int idMusic)
        {
            var view = ApiService.UpdateView(idMusic);
            return Json(new { data = view }, JsonRequestBehavior.AllowGet);
        }
    }
}