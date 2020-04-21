using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppAdmin.Areas.Client.Models.ServiceClient;
using AppAdmin.Common;
using AppAdmin.Models.Service;
using ModelViews.DTOs;

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
            var UserId = (UserDTO)Session[CommonConstants.USER_SESSION];
            Session["UserSession"] = (UserDTO)Session[CommonConstants.USER_SESSION];
            if (Session["UserSession"] != null)
            {
                if (ApiService.GetPlaylistByIdUser(UserId.ID).Count() > 0)
                {
                    ViewBag.getPlaylistByIdUser = ApiService.GetPlaylistByIdUser(UserId.ID);
                }
                else
                {
                    ViewBag.getPlaylistByIdUser = null;
                }
                
            }
            else
            {
                ViewBag.getPlaylistByIdUser = null;
            }
            return View();
        }
        public JsonResult AddMusicPlaylist(PlaylistMusicDTO playlistMusicDTO)
        {
            var data = ApiService.CreatePlaylistMusic(playlistMusicDTO);
            if (data != null)
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
    }
}