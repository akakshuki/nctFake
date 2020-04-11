using AppAdmin.Models.Service;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        #region Singer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            Session["id"] = id;
            var data = ApiService.GetUserById(id);
            return View(data);
        }

        public ActionResult CreateSinger(UserDTO userDTO)
        {
            var data = ApiService.CreateSinger(userDTO);
            if (data != null)
            {
                return RedirectToAction("ListSinger");
            }
            return RedirectToAction("Index");
        }
        public ActionResult UpdateSinger(UserDTO userDTO)
        {
            var data = ApiService.UpdateSinger(userDTO);
            if (data != null)
            {
                return RedirectToAction("ListSinger");
            }
            return RedirectToAction("Edit",new {id = Session["id"] });
        }
        public ActionResult DeleteUser(int id)
        {
            ApiService.DeleteUser(id);
            ViewBag.GetSinger = ApiService.GetAllSinger();
            return RedirectToAction("ListSinger");
        }
        public ActionResult ListSinger()
        {
            ViewBag.GetSinger = ApiService.GetAllSinger();
            return View();
        }
        #endregion
        #region User Normal & Vip
        public ActionResult ListUser()
        {
            ViewBag.ListUser = ApiService.GetAllUserNormal();
            ViewBag.ListUserVip = ApiService.GetAllUserVip();
            return View();
        }
        public ActionResult ViewDetails(int id)
        {
            ViewBag.PlaylistUser = ApiService.GetPlaylistByIdUser(id);
            ViewBag.Order = ApiService.GetOrderVipByIdUser(id);
            return View();
        }
        #endregion
    }
}