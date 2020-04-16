using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppAdmin.Models.Service;
using ModelViews.DTOs;

namespace AppAdmin.Controllers
{
    public class MusicRankController : Controller
    {
        // GET: MusicRank
        public ActionResult Index()
        {
            ViewBag.ListRankThisWeek = ApiService.GetListRankThisWeek();
            return View();
        }


        public ActionResult ListRanks()
        {
            var list = ApiService.GetAllRank();
            ViewBag.ListRankSongs = list.Where(x => x.SongOrMusic).OrderByDescending(x=>x.ID).ToList();
            ViewBag.ListRankMvs = list.Where(x => !x.SongOrMusic).OrderByDescending(x => x.ID).ToList();
            return View();
        }

        public ActionResult CreateRank()
        {
            ViewBag.ListOldRank = ApiService.GetAllRank();
            ViewBag.ListCategories = ApiService.GetAllCate();
            return View();
        }

        [HttpPost]
        public ActionResult CreateRank(RankDTO rank)
        {
            ViewBag.ListOldRank = ApiService.GetAllLastWeekRank();
            ViewBag.ListCategories = ApiService.GetAllCate();
            if (!ModelState.IsValid) return View();
            if (ApiService.CreateNewRank(rank)) return RedirectToAction("ListRanks");
            return View();

        }
        [HttpGet]
        public ActionResult EditRank(int id)
        {
            ViewBag.ListCategories = ApiService.GetAllCate();
            var data = ApiService.GetAllRank().SingleOrDefault(x => x.ID == id);

            return View(data);
        }
        [HttpPost]
        public ActionResult EditRank(RankDTO rank)
        {
            ViewBag.ListCategories = ApiService.GetAllCate();
            var data = ApiService.GetAllRank().SingleOrDefault(x => x.ID == rank.ID);
            if (!ModelState.IsValid) return View(data);
            if (ApiService.UpdateRank(rank)) return RedirectToAction("ListRanks");
            return View(data);
        }

        [HttpGet]
        public JsonResult GetRankById(int id)
        {
            var data = ApiService.GetAllRank().SingleOrDefault(x => x.ID == id);
            return Json(new
            {
                data = data
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetOldRank(int id)
        {
            ViewBag.OldRanks = ApiService.GetOldRank(id);
            ViewBag.OldRankDetail = ApiService.GetAllRank().SingleOrDefault(x=>x.ID==id);

            return View();
        }


        public ActionResult DeleteRank(int id)
        {
            ApiService.DeleteRank(id);
            return RedirectToAction("ListRanks");
        }


    }
}