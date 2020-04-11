using AppAdmin.Models.Service;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Controllers
{
    public class QualityMusicController : Controller
    {
        // GET: QualityMusic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewCreate(int id)
        {
            Session["idQ"] = id;
            ViewBag.getQuanlity = ApiService.GetAllQuality();
            ViewBag.getList = ApiService.GetFileByIdMusic(id);
            return View();
        }
        public ActionResult Edit(int id)
        {
            ViewBag.getQuanlity = ApiService.GetAllQuality();
            var data = ApiService.GetQualityMusicById(id);
            return View(data);
        }
    
        public ActionResult Create(QualityMusicDTO qualityMusic)
        {
            var data = ApiService.CreateQualityMusic(qualityMusic);
            if (data != null)
            {
                return RedirectToAction("ViewCreate", new { id = qualityMusic.MusicID });
            }
            return RedirectToAction("ViewCreate", new { id = qualityMusic.MusicID });
        }
        public ActionResult Update(QualityMusicDTO qualityMusic)
        {
            var data = ApiService.UpdateQualityMusic(qualityMusic);
            if (data != null)
            {
                return RedirectToAction("ViewCreate", new { id = qualityMusic.MusicID });
            }
            return RedirectToAction("ViewCreate", new { id = qualityMusic.MusicID });
        }
        public ActionResult Delete(int id)
        {
            ApiService.DeleteQualityMusic(id);
            return RedirectToAction("ViewCreate", new { id = Session["idQ"] });
        }
        public ActionResult EditFile(int id)
        {
            Session["idM"] = id;
            ViewBag.getQuanlity = ApiService.GetAllQuality();
            var data = ApiService.GetQualityMusicById(id);
            return View(data);
        }
        public ActionResult ListFile()
        {
            ViewBag.listFile = ApiService.GetAllQM();
            return View();
        }
        public ActionResult UpdateFile(QualityMusicDTO qualityMusic)
        {
            var data = ApiService.UpdateFile(qualityMusic);
            if (data != null)
            {
                return RedirectToAction("ListFile");
            }
            return RedirectToAction("EditFile", new { id = qualityMusic.MusicID });
        }

        public ActionResult DeleteFile(int id)
        {
            ApiService.DeleteQualityMusic(id);
            return RedirectToAction("ViewCreate", new { id = Session["idQ"] });
        }

    }
}