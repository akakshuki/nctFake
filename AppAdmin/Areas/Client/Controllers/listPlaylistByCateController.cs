
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
    public class listPlaylistByCateController : Controller
    {
        // GET: Client/listPlaylistByCate
        public ActionResult Index(int id)
        {
            ViewBag.getListPlaylist = ApiService.GetPlaylistByIdCate(id).Where(x=>x.UserDto.RoleID == 1 || x.UserDto.RoleID == 2).ToList();
            Session["RoleId"] = (UserDTO)Session[CommonConstants.USER_SESSION];
            return View();
        }
    }
}