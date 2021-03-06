﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppAdmin.Areas.Client.Models.ServiceClient;
using AppAdmin.Common;
using ModelViews.DTOs;
using ApiService = AppAdmin.Models.Service.ApiService;

namespace AppAdmin.Areas.Client.Controllers
{
    public class HomeController : Controller
    {
        // GET: Client/Home
        public ActionResult Index()
        {
            ViewBag.RandomTheoChuDe = ApiService.GetAllCate().Where(s => s.ID_root != null).Distinct().OrderBy(s => Guid.NewGuid()).Take(5).ToList();
            ViewBag.GetPartner = ApiService.GetAllPartner();
            var data = ApiService.GetAllMusic();
            ViewBag.GetSinger = data;
            ViewBag.GetTop10SongNew = data.Where(s => s.SongOrMV == true).OrderByDescending(s => s.MusicDayCreate).Take(10).ToList();
            ViewBag.GetTop10MVNew = data.Where(s => s.SongOrMV == false).OrderByDescending(s => s.MusicDayCreate).Take(10).ToList();
            return View();
        }


        public ActionResult RankMusicThisWeek(int id)
        {
            var data = ApiService.GetListRankThisWeek().Where(x => x.CateID == id).ToList();
            ViewBag.idCate = id;
            ViewBag.ListRank = data;
            return View();
        }

        public ActionResult NavigationMenu()
        {
            Session["UserSession"] = (UserDTO)Session[CommonConstants.USER_SESSION];
            if (Session["UserSession"]!=null)
            {
                var idUser = (UserDTO)Session[CommonConstants.USER_SESSION];
                Session["UserId"] = idUser.ID;
                ViewBag.getUserById = ApiService.GetUserById(idUser.ID);
            }
            else
            {
                Session["UserId"] = null;
                ViewBag.getUserById = null;
            }
            var data = ApiService.GetAllCateCon();
            ViewBag.getCate = data;
            ViewBag.getSubCate = data.Where(s => s.ID_root != null).ToList();
            ViewBag.getTheoChuDe = ApiService.GetAllCate().Where(s => s.ID_root != null).ToList();
            return PartialView();
        }

        public ActionResult SearchPage(string name)
        {
            var music = ApiService.GetAllMusic()
                .Where(x => x.MusicName.ToLower().ToString().Contains(name.ToLower()) ||
                            x.MusicNameUnsigned.ToLower().Contains(name.ToLower()))
               .ToList();
            ViewBag.Key = name;
            ViewBag.Music = music.Where(x => x.SongOrMV).Take(100).ToList();
            ViewBag.Video = music.Where(x => !x.SongOrMV).Take(100).ToList();
            ViewBag.Singer = ApiService.GetAllSinger().Where(x => x.UserName.ToLower().ToString().Contains(name.ToLower()) || x.UserNameUnsigned.ToLower().Contains(name.ToLower())).Take(100).ToList();
            ViewBag.PlayList = ApiService.GetAllPlaylist().Where(x => x.PlaylistName.ToLower().Contains(name.ToLower())).Take(100).ToList();
            //ViewBag.getAllPlaylistMusic = ApiService.GetAllPlaylistMusic();
            return View();
        }


        #region Search for search input

        [HttpGet]
        public JsonResult SearchMusicByKey(string name)
        {
            var list = ApiService.GetMusicByName(name)
                .Where(x => x.MusicName.ToLower().ToString().Contains(name.ToLower()) || x.MusicNameUnsigned.ToLower().Contains(name.ToLower()))
                .Take(5)
                .Where(x => x.SongOrMV == true)
                .ToList();

            return Json(new
            {
                data = list
            }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult SearchVideoByKey(string name)
        {
            var list = ApiService.GetMusicByName(name)
                .Where(x => x.MusicName.ToLower().ToString().Contains(name.ToLower()) || x.MusicNameUnsigned.ToLower().Contains(name.ToLower()))
                .Take(5)
                .Where(x => x.SongOrMV == false)
                .ToList(); return Json(new
                {
                    data = list
                }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult SearchSingerByKey(string name)
        {
            var list = ApiService.GetSingerByName(name).Where(x => x.UserName.ToLower().ToString().Contains(name.ToLower()) || x.UserNameUnsigned.ToLower().Contains(name.ToLower())).Take(5).ToList();

            return Json(new
            {
                data = list
            }, JsonRequestBehavior.AllowGet);

        }

        #endregion
    }
}