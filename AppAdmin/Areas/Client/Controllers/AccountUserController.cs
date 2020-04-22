using AppAdmin.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelViews.DTOs;

namespace AppAdmin.Areas.Client.Controllers
{
    public class AccountUserController : Controller
    {
        // GET: Client/AccountUser
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AccountUser(int id)
        {
            ViewBag.getOrderVipByIdUser = ApiService.GetOrderVipByIdUser(id);
            return View();
        }

        public ActionResult HistoryUser()
        {
            var user = (UserDTO) Session[Common.CommonConstants.USER_SESSION];
            ViewBag.user = user;
            if (user == null) return RedirectToAction("Login", "Login");
            ViewBag.HistoryUser = ApiService.HistoryUserList(user.ID);
            return View();
        }


        public ActionResult DeleteHistoryUser(int id)
        {
            var user = (UserDTO)Session[Common.CommonConstants.USER_SESSION];
            if (user == null) return RedirectToAction("Login", "Login");
            if (ApiService.DeleteHistoryUser(user.ID, id))
            {
                SetAlert("Xóa thành công", "success");
            }
            else
            {
                SetAlert("Xóa không thành  công", "error");
            }

            return RedirectToAction("HistoryUser");
        }




        public ActionResult DeleteAllHistoryUser(int id)
        {
          
            if (ApiService.DeleteAllHistoryUser(id))
            {
                SetAlert("Xóa thành công", "success");
            }
            else
            {
                SetAlert("Xóa không thành  công", "error");
            }

            return RedirectToAction("HistoryUser");
        }

        private void SetAlert(string message, string type)
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