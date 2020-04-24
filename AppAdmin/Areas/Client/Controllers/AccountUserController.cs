using AppAdmin.Models.Service;
using ModelViews.DTOs;
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
        private string path = "";
        public AccountUserController()
        {
            path = "~/File/ImageUser/";
        }
        // GET: Client/AccountUser
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AccountUser(int id)
        {
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
            if (u.DayVipEnd != null)
            {
                ViewBag.dateVip = (DateTime)u.DayVipEnd;
            }
            else
            {
                ViewBag.dateVip = null;
            }
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
        public ActionResult UpdatePassword(UserDTO userDTO)
        {
            var data = ApiService.UpdatePassword(userDTO);
            if (data != null)
            {
                SetAlert("Update success!", "success");
                return RedirectToAction("AccountUser", new { id = userDTO.ID });
            }
            SetAlert("Update fail!", "danger");
            return RedirectToAction("AccountUser", new { id = userDTO.ID });
        }
        public ActionResult UpdateUser(UserDTO userDTO)
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
                var data = ApiService.UpdateUser(userDTO);
                if (data != null)
                {
                    SetAlert("Update success!", "success");
                    return RedirectToAction("AccountUser", new { id = userDTO.ID });
                }
                SetAlert("Update fail!", "danger");
                return RedirectToAction("AccountUser", new { id = userDTO.ID });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                SetAlert("Update fail!", "danger");
                return RedirectToAction("AccountUser", new { id = userDTO.ID });
            }
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


    }
}