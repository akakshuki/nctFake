using System;
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
            ViewBag.RandomTheoChuDe = ApiService.GetAllCateCon().Where(s => s.ID_root != null).Distinct().OrderBy(s=> Guid.NewGuid()).Take(5).ToList();
            ViewBag.GetPartner = ApiService.GetAllPartner();
            ViewBag.GetSinger = ApiService.GetAllMusic();
            ViewBag.GetTop10SongNew = ApiService.GetAllMusic().Where(s=> s.SongOrMV == true).OrderByDescending(s=>s.MusicDayCreate).Take(10).ToList();
            ViewBag.GetTop10MVNew = ApiService.GetAllMusic().Where(s => s.SongOrMV == false).OrderByDescending(s => s.MusicDayCreate).Take(10).ToList();
            return View();
        }


        public ActionResult RankMusicThisWeek(int id)
        {
            var data = ApiService.GetListRankThisWeek().Where(x=>x.CateID== id).ToList();
            ViewBag.idCate = id;
            ViewBag.ListRank = data;
            return View();
        }

        public ActionResult NavigationMenu()
        {
            Session["UserSession"] = (UserDTO)Session[CommonConstants.USER_SESSION];
            ViewBag.getCate = ApiService.GetAllCate();
            ViewBag.getSubCate = ApiService.GetAllCateCon().Where(s => s.ID_root != null).ToList();
            ViewBag.getTheoChuDe = ApiService.GetAllCateCon().Where(s=>s.ID_root != null).ToList();
            return PartialView();
        }

        public ActionResult SearchPage()
        {

           
            return View();
        }


        #region Search for search input

        [HttpGet]
        public JsonResult SearchMusicByKey(string name)
        {
            var  list = ApiService.GetAllMusic()
                .Where(x => x.MusicName.ToLower().ToString().Contains(name.ToLower()) || x.MusicNameUnsigned.ToLower().Contains(name.ToLower()))
                .Take(5)
                .Where(x=>x.SongOrMV == true)
                .ToList();

            return Json(new
            {
                data = list
            },JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult SearchVideoByKey(string name)
        {
            var list = ApiService.GetAllMusic()
                .Where(x => x.MusicName.ToLower().ToString().Contains(name.ToLower()) || x.MusicNameUnsigned.ToLower().Contains(name.ToLower()) )
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
            var list = ApiService.GetAllSinger().Where(x=>x.UserName.ToLower().ToString().Contains(name.ToLower()) || x.UserNameUnsigned.ToLower().Contains(name.ToLower())).ToList();

            return Json(new
            {
                data = list
            }, JsonRequestBehavior.AllowGet);

        }

        #endregion
    }
}