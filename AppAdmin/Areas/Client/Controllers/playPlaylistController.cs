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
            ViewBag.GetSinger = ApiService.GetAllMusic();
            var getIdMusic = ApiService.GetPlaylistById(id);
          
            ViewBag.getFile = ApiService.GetAllQM().Where(s=>s.QualityID==1).ToList();
            var UserId = (UserDTO)Session[CommonConstants.USER_SESSION];
            Session["UserSession"] = (UserDTO)Session[CommonConstants.USER_SESSION];           
            if (Session["UserSession"] != null)
            {
                data.UserID = UserId.ID;
                ViewBag.getPlaylistByIdUser = ApiService.GetPlaylistByIdUser(data.UserID);
            }
            else
            {
                ViewBag.getPlaylistByIdUser = null;
            }           

            return View();
        }
    }
}