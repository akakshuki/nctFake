using AppAdmin.Models.Service;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Areas.Client.Controllers
{
    public class EditPlaylistController : Controller
    {
        private string path = "";
        public EditPlaylistController()
        {
            path = "~/File/ImagePlaylist/";
        }
        // GET: Client/EditPlaylist
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditPLaylist(int id)
        {
            Session["IdEditPl"] = id;
            ViewBag.getMusicByIdPlaylist = ApiService.GetMusicByIdPlaylist(id);
            ViewBag.getCate = ApiService.GetAllCate().Where(s => s.ID_root != null).ToList();
            var data = ApiService.GetPlaylistById(id);
            return View(data);
        }
        public ActionResult UpdatePlaylist(PlaylistDto playlistDTO)
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

                    if (playlistDTO.FileImage != null)
                    {
                        //delete file
                        var filePath = Server.MapPath(path + currentFileName);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        playlistDTO.PlaylistImage = DateTime.Now.Ticks + playlistDTO.PlaylistImage + ".png";
                        playlistDTO.FileImage.SaveAs(Server.MapPath(path + playlistDTO.PlaylistImage));
                        playlistDTO.FileImage = null;
                    }
                    else
                    {
                        playlistDTO.PlaylistImage = currentFileName;
                    }
                }
                var data = ApiService.UpdatePlaylist(playlistDTO);
                if (data != null)
                {
                    SetAlert("Update success!", "success");
                    return RedirectToAction("PersonalUser", "PersonalUser", new { id = Session["UserId"] });
                }
                SetAlert("Update fail!", "danger");
                return RedirectToAction("EditPLaylist", new { id = playlistDTO.ID });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                SetAlert("Update fail!", "danger");
                return RedirectToAction("EditPLaylist", new { id = playlistDTO.ID });
            }


        }
        public ActionResult DeleteMusicInPlaylist(int id)
        {
            ApiService.DeletePlaylistMusic(id);
            SetAlert("Delete success", "success");
            return RedirectToAction("EditPLaylist",new { id = Session["IdEditPl"] });
        }
        public ActionResult DeletePlaylistAndPlaylistMusic(int id)
        {
            ApiService.DeletePlaylistAndPlaylistMusic(id);
            SetAlert("Delete success", "success");
            return RedirectToAction("PersonalUser", "PersonalUser", new { id = Session["UserId"] });
        }
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}