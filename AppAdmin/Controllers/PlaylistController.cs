﻿using AppAdmin.Models.Service;
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
        private string path = "";
        public PlaylistController()
        {
            path = "~/File/ImagePlaylist/";
        }
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
        [HttpPost]
        public ActionResult Create(PlaylistDTO playlistDTO)
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
                    return RedirectToAction("Index", "Playlist", new { id = Session["id"] });
                }
                return RedirectToAction("Index", new { id = playlistDTO.UserID });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Index", new { id = playlistDTO.UserID });
            }
          
        }
        [HttpPost]
        public ActionResult Update(PlaylistDTO playlistDTO)
        {
            try
            {
                //get Image have exist
                var currentFileName = ApiService.GetPlaylistById(playlistDTO.ID).PlaylistImage;
                //check name have deafault if exist ==> dont delete
                if (currentFileName == "default.png")
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
                }
                else
                {
                    //delete file
                    var filePath = Server.MapPath(path + currentFileName);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

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
                }
                var data = ApiService.UpdatePlaylist(playlistDTO);
                if (data != null)
                {
                    return RedirectToAction("Index", new { id = playlistDTO.UserID });
                }
                return RedirectToAction("Edit", new { id = playlistDTO.ID });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Edit", new { id = playlistDTO.ID });
            }

        }
        public ActionResult Delete(int id)
        {
            ApiService.DeletePlaylist(id);
            return RedirectToAction("Index", new { id = Session["id"]});
        }
        public ActionResult AddMusicForPlaylist(int id)
        {
            Session["idPl"] = id;
            ViewBag.listMusic = ApiService.GetAllMusic();
            ViewBag.getMuiscInPlaylist = ApiService.GetMusicByIdPlaylist(id);
            ViewBag.Playlist = ApiService.GetPlaylistById(id);
            return View();
        }
        public ActionResult CreateMusicForPlaylist(PlaylistMusicDTO playlistMusic)
        {
            var data = ApiService.CreatePlaylistMusic(playlistMusic);
            if (data != null)
            {
                RedirectToAction("AddMusicForPlaylist", new { id = playlistMusic.PlaylistID });
            }
            return RedirectToAction("AddMusicForPlaylist", new { id = playlistMusic.PlaylistID });
        }
        public ActionResult DeletePlaylistMusic(int id)
        {
            var data = ApiService.DeletePlaylistMusic(id);
            return RedirectToAction("AddMusicForPlaylist", new { id = Session["idPl"] });
        }
    }
}