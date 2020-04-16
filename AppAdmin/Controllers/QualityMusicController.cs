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
        private readonly string _path;
        public QualityMusicController()
        {
            _path = "~/File/mp3-mp4/";
        }
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
        [HttpPost]
        public ActionResult Create(QualityMusicDTO qualityMusic)
        {

            var dataMusic = ApiService.GetMusicById(qualityMusic.MusicID);

            var checkQuality = ApiService.GetAllQM().Where(x => x.QualityID == qualityMusic.QualityID && x.MusicID == qualityMusic.MusicID);
            if (checkQuality.Count() > 1) return RedirectToAction("Index");

            try
            {
                if (qualityMusic.FileQ != null)
                {
                    if (dataMusic.SongOrMV)
                    {
                        qualityMusic.MusicFile = DateTime.Now.Ticks + dataMusic.MusicName + ".mp3";
                    }
                    else
                    {
                        qualityMusic.MusicFile = DateTime.Now.Ticks + dataMusic.MusicName + ".mp4";
                    }
                    qualityMusic.FileQ.SaveAs(Server.MapPath(_path + qualityMusic.MusicFile));
                    qualityMusic.FileQ = null;
                }

                var data = ApiService.CreateQualityMusic(qualityMusic);
                return RedirectToAction("ViewCreate", new { id = qualityMusic.MusicID });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index");
            }



        }
        [HttpPost]
        public ActionResult Update(QualityMusicDTO qualityMusic)
        {
            try
            {
                //get Image have exist
                var currentFileName = ApiService.GetQualityMusicById(qualityMusic.ID).MusicFile;
                //check name have deafault if exist ==> dont delete
                if (currentFileName == "default.png")
                {
                    if (qualityMusic.FileQ != null)
                    {
                        qualityMusic.MusicFile = DateTime.Now.Ticks + qualityMusic.MusicFile + ".png";
                        qualityMusic.FileQ.SaveAs(Server.MapPath(_path + qualityMusic.MusicFile));
                        qualityMusic.FileQ = null;
                    }
                    else
                    {
                        qualityMusic.MusicFile = "default.png";
                    }
                }
                else
                {

                    if (qualityMusic.FileQ != null)
                    {
                        //delete file
                        var filePath = Server.MapPath(_path + currentFileName);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        qualityMusic.MusicFile = DateTime.Now.Ticks + qualityMusic.MusicFile + ".png";
                        qualityMusic.FileQ.SaveAs(Server.MapPath(_path + qualityMusic.MusicFile));
                        qualityMusic.FileQ = null;
                    }
                    else
                    {
                        qualityMusic.MusicFile = currentFileName;
                    }
                }
                var data = ApiService.UpdateQualityMusic(qualityMusic);
                if (data != null)
                {
                    return RedirectToAction("ViewCreate", new { id = qualityMusic.MusicID });
                }
                return RedirectToAction("ViewCreate", new { id = qualityMusic.MusicID });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("ViewCreate", new { id = qualityMusic.MusicID });
            }

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