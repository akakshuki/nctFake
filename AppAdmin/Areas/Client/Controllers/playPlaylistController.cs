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
            var data = ApiService.GetPlaylistById(id);
            ViewBag.getPlaylistById = data;
            ViewBag.getListPlaylist = ApiService.GetPlaylistByIdCate(data.CateID??0).Distinct().OrderBy(s => Guid.NewGuid()).Take(3).ToList();
            ViewBag.getPlaylistMusic = ApiService.GetMusicByIdPlaylist(id);
            ViewBag.GetAllMusic = ApiService.GetAllMusic();
            var getIdMusic = data;
          
            ViewBag.getFile = ApiService.GetAllQM().Where(s=>s.QualityID==1).ToList();
            var UserId = (UserDTO)Session[CommonConstants.USER_SESSION];
            if (UserId != null)
            {
                Session["UserIdPl"] = UserId.ID;
            }
            else
            {
                Session["UserIdPl"] = null;
            }
          
            Session["UserSession"] = (UserDTO)Session[CommonConstants.USER_SESSION];           
            if (UserId != null)
            {
                var playlistByIdUser = ApiService.GetPlaylistByIdUser(UserId.ID);
                if (playlistByIdUser.Count() > 0)
                {
                    ViewBag.getPlaylistByIdUser = playlistByIdUser;
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