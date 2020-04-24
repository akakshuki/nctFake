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

            if (ApiService.GetAllQM().Count(x =>
                    x.QualityID == qualityMusic.QualityID && x.MusicID == qualityMusic.MusicID) >= 1)
            {
                TempData["error"] = "Have already quality file !  ";
                return RedirectToAction("ViewCreate", new { id = qualityMusic.MusicID });
            }

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
                var dataMusic = ApiService.GetMusicById(qualityMusic.MusicID);
                var checkQuality = ApiService.GetAllQM().SingleOrDefault(x => x.QualityID == qualityMusic.QualityID && x.MusicID == qualityMusic.MusicID);


                if (qualityMusic.FileQ != null)
                {
                    if (checkQuality != null)
                    {
                        var filePath = Server.MapPath(_path + checkQuality.MusicFile);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }

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


                    TempData["success"] = "update new file success!";
                }
                else
                {
                    TempData["success"] = "update success!";
                    if (checkQuality != null) qualityMusic.MusicFile = checkQuality.MusicFile;
                }

                ApiService.UpdateQualityMusic(qualityMusic);



            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                TempData["error"] = "Cant update quality music";
                throw;
            }

            return RedirectToAction("ViewCreate", new { id = qualityMusic.MusicID });

        }
        public ActionResult Delete(int id)
        {
            var checkQuality = ApiService.GetQualityMusicById(id);
            var filePath = Server.MapPath(_path + checkQuality.MusicFile);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
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
        public ActionResult UpdateFile(int id)
        {
            var data = ApiService.UpdateFile(id);
            return RedirectToAction("ListFile", "QualityMusic");
        }

        public ActionResult DelFileAndTableRelated(int id)
        {
            var data = ApiService.DelFileAndTableRelated(id);
            return RedirectToAction("ListFile", "QualityMusic");
        }

    }
}