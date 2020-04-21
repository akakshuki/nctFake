using AppAdmin.Common;
using AppAdmin.Models.Service;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Areas.Client.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: Client/UploadFile
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UploadFile()
        {
            var data = (UserDTO)Session[CommonConstants.USER_SESSION];           
            Session["singer"] = ApiService.GetAllSinger();
            if (data != null)
            {
                Session["UserId-UF"] = data.ID;
            }
            else
            {
                if (Session["UserId-UF"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            ViewBag.lsCate = ApiService.GetAllCateCon().Where(s => s.ID_root != null).ToList();
            Session.Remove("singer");
            return View();
        }
        [HttpGet]
        public JsonResult SearchSingerUpload(string value)
        {
            var ls = ApiService.GetListSingerSearch(value);
            return Json(new { lsData = ls }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetListSinger(int number)
        {
            List<int> arr = new List<int>();
            if (Session["singer"] != null)
            {
                arr = Session["singer"] as List<int>;
                arr.Add(number);
                Session["singer"] = arr;
            }
            else
            {
                arr.Add(number);
                Session["singer"] = arr;
            }
            return Json(new { data = number }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult RemoveIdSinger(int id)
        {
            List<int> arr = new List<int>();
            arr = Session["singer"] as List<int>;
            arr.Remove(id);
            Session["singer"] = arr;
            return Json(new { data = id }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateMusicUser(MusicDTO m, HttpPostedFileBase fileMusic, HttpPostedFileBase imgMusic)
        {
            Session["singer"] = ApiService.GetAllSinger();
            if (Session["singer"]!=null)
            {
                List<int> arrSinger = new List<int>();
                arrSinger = Session["singer"] as List<int>;
                m.MusicNameUnsigned = RemoveUnicode.RemoveSign4VietnameseString(m.MusicName);
                m.MusicDownloadAllowed = true;
                m.MusicView = 0;
                m.UserID = 48;
                //img music
                if (imgMusic == null)
                {
                    m.MusicImage = "default.png";
                }
                else
                {
                    string FileNameMusic = DateTime.Now.Ticks + Path.GetFileName(imgMusic.FileName);
                    string pathMusic = Path.Combine(Server.MapPath("~/File/ImagesMusic"), FileNameMusic);
                    imgMusic.SaveAs(pathMusic);
                    m.MusicImage = FileNameMusic;
                }
                //quality music
                QualityMusicDTO quality = new QualityMusicDTO()
                {
                    NewFile = true,
                    QMusicApproved = false
                };
                string FileName = DateTime.Now.Ticks + Path.GetFileName(fileMusic.FileName);
                string path;
                if (FileName.EndsWith("mp3"))
                {
                    quality.QualityID = 1; //file normal of song
                    m.SongOrMV = true;
                    path = Path.Combine(Server.MapPath("~/File/mp3-mp4"), FileName);
                }
                else
                {
                    quality.QualityID = 3; //file mormal of mv
                    m.SongOrMV = false;
                    path = Path.Combine(Server.MapPath("~/File/mp3-mp4"), FileName);
                }
                fileMusic.SaveAs(path);
                quality.MusicFile = FileName;
                // music
                var data = ApiService.CreateMusicUpload(m);
                if (data != null)
                {
                    int idMusic = data;
                    quality.MusicID = idMusic;
                    var dataQM = ApiService.CreateQualityMusic(quality);
                    if (dataQM != null)
                    {
                        //singer
                        foreach (var number in arrSinger)
                        {

                        }
                        TempData["success"] = "Upload file thành công";
                    }
                }

            }
            else
            {
                TempData["error"] = "Upload file xảy ra lỗi";
            }
            Session.Remove("singer");
            return RedirectToAction("UploadFile");
        }
    }
}