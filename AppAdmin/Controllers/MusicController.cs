using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppAdmin.Models.Service;
using ModelViews.DTOs;

namespace AppAdmin.Controllers
{
    public class MusicController : Controller
    {
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
            return View();
        }

        // GET: Music/Create
        public ActionResult Create()
        {
            ViewBag.Singers = ApiService.GetAllSinger();
         
            return View();
        }

        // POST: Music/Create
        [HttpPost]
        public ActionResult Create(MusicDTO music)
        {
            try
            {
                var res = ApiService.CreateMusic(music);
                if (res)
                {
                    var data = ApiService.GetAllMusic();
                    return RedirectToAction("Index","Music", data);
                }

                return RedirectToAction("Create");

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return RedirectToAction("Create");
            }
        }

        // GET: Music/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Singers = ApiService.GetAllSinger();
            var data = ApiService.GetMusicById(id);
            return View(data);
        }

        // POST: Music/Edit/5
        [HttpPost]
        public ActionResult Edit(MusicDTO music)
        {
            try
            {
                var res = ApiService.UpdateMusic(music);
                if (res)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Edit");
            }
            catch
            {
                return RedirectToAction("Edit");
            }
        }

        // GET: Music/Delete/5
        public ActionResult Delete(int id)
        {
            var res = ApiService.DeleteMusic(id);
            var musics = new List<MusicDTO>();
            if (res)
            {
               musics = ApiService.GetAllMusic();
                return RedirectToAction("Index","Music", musics);
            }
            musics = ApiService.GetAllMusic();
            return RedirectToAction("Index", "Music", musics);

        }

     
    }
}
