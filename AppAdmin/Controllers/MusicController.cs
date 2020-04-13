using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppAdmin.Models.Service;
using ModelViews.DTOs;

namespace AppAdmin.Controllers
{
    public class MusicController : Controller
    {
        private string path = "";

        public MusicController()
        {
            path = "~/File/ImageMusic/";
        }

        // GET: Music
        public ActionResult Index()
        {
            var music = ApiService.GetAllMusic();
            return View(music);
        }


        public JsonResult ListMusicByPaging(Pagination pagination)
        {
            var music = ApiService.GetPagingMusic(pagination);

            return Json(new
            {
                data = music
            });
        }

        // GET: Music/Details/5
        public ActionResult Details(int id)
        {
            var data = ApiService.GetMusicById(id);
            return View();
        }

        // GET: Music/Create
        public ActionResult Create()
        {
            ViewBag.Categories = ApiService.GetAllListCategories().Where(x=>x.ID_root != null).ToList();
            ViewBag.MusicRelated = ApiService.GetAllMusic();
            return View();
        }

        // POST: Music/Create
        [HttpPost]
        public ActionResult Create(MusicDTO music)
        {
            try
            {
                music.UserID = 31;

                if (music.FileImage != null)
                {
                    music.MusicImage = DateTime.Now.Ticks + music.MusicName + ".png";
                    music.FileImage.SaveAs(Server.MapPath(path + music.MusicImage));
                    music.FileImage = null;
                }
                else
                {
                    music.MusicImage = "default.png";
                }
                var res = ApiService.CreateMusic(music);
                if (res)
                {
                    var data = ApiService.GetAllMusic();
                    return RedirectToAction("Index", "Music", data);
                }

                return RedirectToAction("Create");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Create");
            }
        }

        // GET: Music/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Categories = ApiService.GetAllListCategories().Where(x => x.ID_root != null).ToList();
            ViewBag.MusicRelateds = ApiService.GetAllMusic();
            var data = ApiService.GetMusicById(id);
            return View(data);
        }

        // POST: Music/Edit/5
        [HttpPost]
        public ActionResult Edit(MusicDTO music)
        {

            try
            {

                //get Image have exist
                var currentFileName = ApiService.GetMusicById(music.ID).MusicImage;
                //check name have deafault if exist ==> dont delete
                if (currentFileName == "default.png")
                {
                    //save file
                    if (music.FileImage != null)
                    {
                        music.MusicImage = DateTime.Now.Ticks.ToString() + music.MusicName + ".png";
                        music.FileImage.SaveAs(Server.MapPath(path + music.MusicImage));
                        music.FileImage = null;
                    }
                    else
                    {
                        music.MusicImage = "default.png";
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

                    if (music.FileImage != null)
                    {
                        music.MusicImage = DateTime.Now.Ticks + music.MusicName + ".png";
                        music.FileImage.SaveAs(Server.MapPath(path + music.MusicImage));
                        music.FileImage = null;
                    }
                    else
                    {
                        music.MusicImage = "default.png";
                    }
                }

                var res = ApiService.UpdateMusic(music);
                if (res)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Edit");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return RedirectToAction("Edit");
            }
        }

        // GET: Music/Delete/5
        public ActionResult Delete(int id)
        {
          
            var musics = new List<MusicDTO>();
            //get Image have exist
            var currentFileName = ApiService.GetMusicById(id).MusicImage;
            //check name have deafault if exist ==> dont delete
            if (currentFileName != "default.png")
            {
                //delete file
                var filePath = Server.MapPath(path + currentFileName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            var res = ApiService.DeleteMusic(id);
            if (res)
            {
                musics = ApiService.GetAllMusic();
                return RedirectToAction("Index", "Music", musics);
            }
            musics = ApiService.GetAllMusic();
            return RedirectToAction("Index", "Music", musics);

        }


        public ActionResult SingerOfMusic(int id)
        {
            ViewBag.ListSingerOfMusic = ApiService.GetSingerOfMusicByMusicId(id);
            ViewBag.Singers = ApiService.GetAllSinger();
            ViewBag.Music = ApiService.GetMusicById(id);
            return View();
        }

        public ActionResult AddSingerToMusic(SingerMusicDTO singerMusic)
        {
            
            ApiService.AddSingerToMusic(singerMusic);
            return RedirectToAction("SingerOfMusic","Music", new {id = singerMusic.MusicID});
        }
        public ActionResult DeleteSingerToMusic(int idValue, int idMusics)
        {
            ApiService.DeleteSingerToMusic(idValue);


            return RedirectToAction("SingerOfMusic", "Music", new { id = idMusics });
        }
    }
}
