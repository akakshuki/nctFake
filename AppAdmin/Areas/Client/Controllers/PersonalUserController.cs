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
    public class PersonalUserController : Controller
    {
        // GET: Client/PersonalUser
        public ActionResult PersonalUser(int id)
        {
            var UserId = (UserDTO)Session[CommonConstants.USER_SESSION];
            Session["UserId"] = UserId.ID;
            ViewBag.getInfoUser = ApiService.GetUserById(id);
            if (ApiService.GetPlaylistByIdUser(id).Count() > 0)
            {
                ViewBag.getPlaylistByIdUser = ApiService.GetPlaylistByIdUser(id);
            }
            else
            {
                ViewBag.getPlaylistByIdUser = null;
            }   
            ViewBag.getSong = ApiService.GetMusicByIdUser(id).Where(s=>s.SongOrMV == true).ToList();
            ViewBag.getMv = ApiService.GetMusicByIdUser(id).Where(s=>s.SongOrMV == false).ToList();
            return View();
        }
    }
}