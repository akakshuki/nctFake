using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppAdmin.Common;
using AppAdmin.Models.Service;
using Facebook;
using ModelViews.DTOs;

namespace AppAdmin.Areas.Client.Controllers
{
    public class LoginController : Controller
    {
        //private Uri RedirectUri
        //{
        //    get
        //    {
        //        var uriBuilder = new UriBuilder(Request.Url);
        //        uriBuilder.Query = null;
        //        uriBuilder.Fragment = null;
        //        uriBuilder.Path = Url.Action("FacebookCallback");
        //        return uriBuilder.Uri;

        //    }
        // }

        //public ActionResult LoginFacebook()
        //{
        //    var fb = new FacebookClient();
        //    var loginUrl = fb.GetLoginUrl(new
        //    {
        //        client_id = ConfigurationManager.AppSettings["FbAppId"],
        //        client_serect = ConfigurationManager.AppSettings["FbAppSerect"],
        //        redirect_uri = RedirectUri.AbsoluteUri,
        //        response_type="code",
        //        scope = "email"
        //    });
        //    return Redirect(loginUrl.AbsoluteUri);
        //}

        //public ActionResult FacebookCallback(string code)
        //{
        //    var fb = new FacebookClient();
        //    dynamic result = fb.Post("oauth/access_token", new
        //    {
        //        client_id = ConfigurationManager.AppSettings["FbAppId"],
        //        client_serect = ConfigurationManager.AppSettings["FbAppSerect"],
        //        redirect_uri = RedirectUri.AbsoluteUri,
        //        code = code
        //    });
        //    var accessToken = result.access_token;
        //    if (string.IsNullOrEmpty(accessToken))
        //    {
        //        fb.AccessToken = accessToken;
        //        //get user's information
        //        dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
        //        string email = me.email;
        //        string userName = me.email;
        //        string firstName = me.first_name;
        //        string middleName = me.middle_name;
        //        string lastName = me.last_name;

        //    }
        //    else
        //    {

        //    }

        //    return Redirect("/");
        //}


        // GET: Client/Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult CreateAccount(UserDTO userDTO)
        {
            var data = ApiService.CreateUser(userDTO);
            if (data != null)
            {
                SetAlert("Register success!", "success");
                return RedirectToAction("Login");
            }
            SetAlert("Email already exists!", "error");
            return RedirectToAction("Login");
        }     
        [HttpPost]
        public ActionResult ResetPassword(string email)
        {
            return View();
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
        //Encryptor.MD5Hash(userDTO.UserPwd),
        public ActionResult LoginUser(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var result = ApiService.Login(userDTO.UserEmail, userDTO.UserPwd);
                if (result == 1)
                {
                    var user = GetIdLogin(userDTO.UserEmail);
                    var userSession = new UserDTO();
                    userSession.ID = user.ID;
                    userSession.UserEmail = user.UserEmail;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("ListSinger", "User");
                }
                else if (result == -3)
                {
                    var user = GetIdLogin(userDTO.UserEmail);
                    var userSession = new UserDTO();
                    userSession.ID = user.ID;
                    userSession.UserEmail = user.UserEmail;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    SetAlert("Account does not exist!", "error");
                    //ModelState.AddModelError("", "Tài khoản không tồn tại!");
                }
                else if (result == -2)
                {
                    SetAlert("Incorrect password!", "error");
                    //ModelState.AddModelError("", "Mật khẩu không đúng!");
                }
                else
                {
                    SetAlert("No account or password has been entered!", "warning");
                    //ModelState.AddModelError("", "Đăng nhập không đúng!");
                }
            }   
            return RedirectToAction("Login");
        }
        public UserDTO GetIdLogin(string email)
        {
            try
            {
                var data = ApiService.GetIdLogin(email);
                var result = new UserDTO()
                {
                    ID = data.ID,
                    UserEmail = data.UserEmail
                };
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                SetAlert("No account or password has been entered!", "warning");
                return null;
            }
        }
    }
}