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
            var UserId = (UserDTO)Session[CommonConstants.USER_SESSION];
            if (UserId == null)
            {
                Session["UserId"] = null;
                ViewBag.getPlaylistByIdUser = null;
            }
            else
            {
                Session["UserId"] = UserId.ID;
                ViewBag.getPlaylistByIdUser = ApiService.GetPlaylistByIdUser(UserId.ID);
            }
           
            //if (Session["UserId"]!=null)
            //{
                
            //}
            //else
            //{
            //    //ham chua loi
            //    ViewBag.getPlaylistByIdUser1 = ApiService.GetPlaylistByIdUser(UserId.ID);
            //}
           
            ViewBag.GetAllMusic = ApiService.GetAllMusic();
            ViewBag.getMusicById = ApiService.GetMusicById(id);
            ViewBag.getLyrics = ApiService.GetLyricByIdMusic(id);
            ViewBag.getMusicRandom = ApiService.GetAllMusic().Distinct().OrderBy(s=> Guid.NewGuid()).Take(5).ToList();
            ViewBag.getListQualityMusic = ApiService.GetFileByIdMusic(id);
            ViewBag.getAllPlaylistMusic = ApiService.GetAllPlaylistMusic();
            ViewBag.getQualityMusicByIdMusic = ApiService.GetQualityMusicByIdMusic(id);
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