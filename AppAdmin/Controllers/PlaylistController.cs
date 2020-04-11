using AppAdmin.Models.Service;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Controllers
{
    public class PlaylistController : Controller
    {
        // GET: Playlist
        public ActionResult Index(int id)
        {
            Session["id"] = id;
            ViewBag.GetCate = ApiService.GetAllCateCon();
            ViewBag.ListPlaylist = ApiService.GetPlaylistByIdUser(id);
            return View();
        }
        public ActionResult Edit(int id) 
        {
            ViewBag.GetCate = ApiService.GetAllCateCon();
            var data = ApiService.GetPlaylistById(id);
            return View(data);
        }

        public ActionResult Create(PlaylistDTO playlistDTO)
        {           
            var data = ApiService.CreatePlaylist(playlistDTO);
            if (data != null)
            {
                return RedirectToAction("Index","Playlist", new { id = Session["id"] });
            }
            return RedirectToAction("Index", new { id = playlistDTO.UserID });
        }
        public ActionResult Update(PlaylistDTO playlistDTO)
        {
            var data = ApiService.UpdatePlaylist(playlistDTO);
            if (data != null)
            {
                return RedirectToAction("Index", new { id = playlistDTO.UserID });
            }
            return RedirectToAction("Edit", new { id = playlistDTO.ID });
        }
        public ActionResult Delete(int id)
        {
            ApiService.DeletePlaylist(id);
            return RedirectToAction("Index", new { id = Session["id"]});
        }
    }
}