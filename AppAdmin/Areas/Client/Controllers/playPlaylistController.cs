using AppAdmin.Common;
using AppAdmin.Models.Service;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Areas.Client.Controllers
{
    public class playPlaylistController : Controller
    {
        // GET: Client/playPlaylist
        public ActionResult Index(int id)
        {
            ViewBag.getPlaylistById = ApiService.GetPlaylistById(id);
            var data = ApiService.GetPlaylistById(id);
            ViewBag.getListPlaylist = ApiService.GetPlaylistByIdCate(data.CateID??0).Distinct().OrderBy(s => Guid.NewGuid()).Take(3).ToList();
            ViewBag.getPlaylistMusic = ApiService.GetMusicByIdPlaylist(id);
            ViewBag.GetAllMusic = ApiService.GetAllMusic();
            var getIdMusic = ApiService.GetPlaylistById(id);
          
            ViewBag.getFile = ApiService.GetAllQM().Where(s=>s.QualityID==1).ToList();
            var UserId = (UserDTO)Session[CommonConstants.USER_SESSION];
            Session["UserIdPl"] = UserId.ID;
            Session["UserSession"] = (UserDTO)Session[CommonConstants.USER_SESSION];           
            if (Session["UserSession"] != null)
            {
                data.UserID = UserId.ID;
                if (ApiService.GetPlaylistByIdUser(data.UserID).Count() > 0)
                {
                    ViewBag.getPlaylistByIdUser = ApiService.GetPlaylistByIdUser(data.UserID);
                }
                ViewBag.getPlaylistByIdUser = null;
            }
            else
            {
                ViewBag.getPlaylistByIdUser = null;
            }           

            return View();
        }
        [HttpGet]
        public JsonResult UpdateView(int idMusic)
        {
            var view = ApiService.UpdateView(idMusic);
            return Json(new { data = view }, JsonRequestBehavior.AllowGet);
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