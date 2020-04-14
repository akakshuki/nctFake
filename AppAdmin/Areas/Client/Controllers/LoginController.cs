using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;

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
        [HttpPost]
        public ActionResult ResetPassword(string email)
        {
            
        }
    }
}