using AppAdmin.Models.Service;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        #region Category
        public ActionResult ViewCreateCate()
        {
            ViewBag.IdRoot = ApiService.GetAllCate().Where(s => s.ID_root == null).ToList();
            ViewBag.GetAllCate = ApiService.GetAllCate().Where(s=>s.ID_root==null).ToList();
            return View();
        }
        public ActionResult ViewCateIdRoot(int id)
        {
            Session["idRoot"] = id;
            ViewBag.GetCateByIdRoot = ApiService.GetCateByIdRoot(id);
            ViewBag.IdRoot = ApiService.GetAllCate().Where(s => s.ID_root == null).ToList();
            return View();
        }
        public ActionResult EditCate(int id)
        {
            ViewBag.IdRoot = ApiService.GetAllCate();
            var data = ApiService.GetCateById(id);
            return View(data);
        }
        public ActionResult EditCateIdRoot(int id)
        {
            ViewBag.IdRoot = ApiService.GetAllCate();
            var data = ApiService.GetCateById(id);
            return View(data);
        }
        public ActionResult CreateCate(CategoryDTO categoryDTO)
        {
            var data = ApiService.CreateCate(categoryDTO);
            if (data != null)
            {
                return RedirectToAction("ViewCreateCate");
            }
            Session["Create"] = "Create Fail";
            return RedirectToAction("ViewCreateCate");
        }
        public ActionResult UpdateCate(CategoryDTO categoryDTO)
        {
            var data = ApiService.UpdateCate(categoryDTO);
            if (data != null)
            {
                return RedirectToAction("ViewCreateCate");
            }
            Session["Update"] = "Update Fail";
            return RedirectToAction("ViewCreateCate");
        }
        public ActionResult UpdateCateIdRoot(CategoryDTO categoryDTO)
        {
            var data = ApiService.UpdateCate(categoryDTO);
            if (data != null)
            {
                return RedirectToAction("ViewCateIdRoot", new { id = categoryDTO.ID_root });
            }
            Session["Update"] = "Update Fail";
            return RedirectToAction("ViewCreateCate");
        }
        public ActionResult DeleteCate(int id)
        {
            ApiService.DeleteCate(id);
            return RedirectToAction("ViewCreateCate");
        }
        public ActionResult DeleteCateIdRoot(int id)
        {
            ApiService.DeleteCate(id);
            return RedirectToAction("ViewCateIdRoot", new { id = Session["idRoot"] });
        }
        public ActionResult GetMusicByIdCate(int id)
        {
            var data = ApiService.GetAllMusic().Where(s => s.CategoryId == id).ToList();
            return View(data);
        }
        #endregion
        public ActionResult ViewLogout()
        {
            return PartialView();
        }
        public ActionResult LogOutAdmin()
        {
            Session[Common.CommonConstants.USER_SESSION] = null;
            return Redirect("https://localhost:44315/Client/Login/Login");
        }
    }
}