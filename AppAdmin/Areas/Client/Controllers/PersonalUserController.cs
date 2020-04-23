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
    public class PersonalUserController : Controller
    {
        // GET: Client/PersonalUser
        private string path = "";
        public PersonalUserController()
        {
            path = "~/File/ImagePlaylist/";
        }
        public ActionResult PersonalUser(int id)
        {
            ViewBag.GetCate = ApiService.GetAllCate().Where(s => s.ID_root != null).ToList();
            var UserId = (UserDTO)Session[CommonConstants.USER_SESSION];
            Session["UserId"] = UserId.ID;
            var u = ApiService.GetUserById(id);
            ViewBag.getInfoUser = u;
            if (u.UserDOB != null)
            {
                ViewBag.date = (DateTime)u.UserDOB;
            }
            else
            {
                ViewBag.date = null;
            }
            if (ApiService.GetPlaylistByIdUser(id).Count() > 0)
            {
                ViewBag.getPlaylistByIdUser = ApiService.GetPlaylistByIdUser(id);
            }
            else
            {
                ViewBag.getPlaylistByIdUser = null;
            }   
            ViewBag.getSong = ApiService.GetMusicByIdUser(id).Where(s=>s.SongOrMV == true).ToList();
            ViewBag.getMv = ApiService.GetMusicByIdUser(id).Where(s=>s.SongOrMV == false).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(PlaylistDto playlistDTO)
        {
            try
            {
                if (playlistDTO.FileImage != null)
                {
                    playlistDTO.PlaylistImage = DateTime.Now.Ticks + playlistDTO.PlaylistImage + ".png";
                    playlistDTO.FileImage.SaveAs(Server.MapPath(path + playlistDTO.PlaylistImage));
                    playlistDTO.FileImage = null;
                }
                else
                {
                    playlistDTO.PlaylistImage = "default.png";
                }
                var data = ApiService.CreatePlaylist(playlistDTO);
                if (data != null)
                {
                    return RedirectToAction("PersonalUser", new { id = Session["UserId"]});
                }
                return RedirectToAction("PersonalUser", new { id = Session["UserId"] });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("PersonalUser", new { id = Session["UserId"] });
            }

        }
        public JsonResult AddMusicPlaylist(PlaylistMusicDTO playlistMusicDTO)
        {
            var data = ApiService.CreatePlaylistMusic(playlistMusicDTO);
            if (data != null)
            {
                return Json(new
                {
                    status = true
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                status = false
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteFile(int id)
        {
            var data = ApiService.DeleteLQ(id);
            return RedirectToAction("PersonalUser", new { id = Session["UserId"] });
        }
    }
}