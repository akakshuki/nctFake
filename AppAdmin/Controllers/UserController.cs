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
        private string path = "";
        public UserController()
        {
            path = "~/File/ImageUser/";
        }
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
        [HttpPost]
        public ActionResult CreateSinger(UserDTO userDTO)
        {
            try
            {
                if (userDTO.FileImage != null)
                {
                    userDTO.UserImage = DateTime.Now.Ticks + userDTO.UserImage + ".png";
                    userDTO.FileImage.SaveAs(Server.MapPath(path + userDTO.UserImage));
                    userDTO.FileImage = null;
                }
                else
                {
                    userDTO.UserImage = "default.png";
                }
                var data = ApiService.CreateSinger(userDTO);
                if (data != null)
                {
                    return RedirectToAction("ListSinger");
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public ActionResult UpdateSinger(UserDTO userDTO)
        {
            try
            {
                //get Image have exist
                var currentFileName = ApiService.GetUserById(userDTO.ID).UserImage;
                //check name have deafault if exist ==> dont delete
                if (currentFileName == "default.png")
                {
                    if (userDTO.FileImage != null)
                    {
                        userDTO.UserImage = DateTime.Now.Ticks + userDTO.UserImage + ".png";
                        userDTO.FileImage.SaveAs(Server.MapPath(path + userDTO.UserImage));
                        userDTO.FileImage = null;
                    }
                    else
                    {
                        userDTO.UserImage = "default.png";
                    }
                }
                else
                {
                    if (userDTO.FileImage != null)
                    {
                        //delete file
                        var filePath = Server.MapPath(path + currentFileName);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        userDTO.UserImage = DateTime.Now.Ticks + userDTO.UserImage + ".png";
                        userDTO.FileImage.SaveAs(Server.MapPath(path + userDTO.UserImage));
                        userDTO.FileImage = null;
                    }
                    else
                    {
                        userDTO.UserImage = currentFileName;
                    }
                }
                var data = ApiService.UpdateSinger(userDTO);
                if (data != null)
                {
                    return RedirectToAction("ListSinger");
                }
                return RedirectToAction("Edit", new { id = Session["id"] });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Edit", new { id = userDTO.ID });
            }

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
        public ActionResult MusicOfSinger(int id)
        {
            ViewBag.getMusicByUser = ApiService.GetAllMusic().Where(x => x.SingerMusicDtOs.Any(k => k.SingerID == id)).ToList();
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
        public ActionResult ListFile(int id)
        {
            ViewBag.getList = ApiService.GetFileByIdMusic(id);
            return View();
        }
        
        public ActionResult ViewDetails(int id)
        {
            ViewBag.getMusicByUser = ApiService.GetAllMusic().Where(s => s.UserID == id).ToList();
            ViewBag.PlaylistUser = ApiService.GetPlaylistByIdUser(id);
            ViewBag.Order = ApiService.GetOrderVipByIdUser(id);
            return View();
        }
        #endregion
    }
}