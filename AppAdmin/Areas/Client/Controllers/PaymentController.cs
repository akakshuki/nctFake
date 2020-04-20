using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppAdmin.Models.Service;
using ModelViews.DTOs;

namespace AppAdmin.Areas.Client.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Client/Payment
        public ActionResult Index()
        {
            ViewBag.PackageVip = ApiService.GetAllPackageVip().ToList();

            return View();
        }

        public ActionResult Payment(int id)
        {
            TempData["PackageVipId"] = id;
            ViewBag.Payment = ApiService.GetAllPayment();

            return View();
        }

        public ActionResult CreateOrderByUser(int idPayment)
        {
            var idPackageVip=(int)TempData["PackageVipId"];
            var idPaymentGate = idPayment;
            var useData = (UserDTO) Session[Common.CommonConstants.USER_SESSION];

            if (idPaymentGate != 1) return View("Index");
            var packageVip = ApiService.GetAllPackageVip().SingleOrDefault(x=>x.ID== idPackageVip);

            if (packageVip != null)
            {

                var link = new MomoService().SetOrderByMomo(Guid.NewGuid(), packageVip.PVipPrice, packageVip.ID, idPaymentGate, useData.UserEmail);
                return Redirect(link.ToString());
            }
            else
            {
                SetAlert("Mua gói vip thành công", "mua gói vip không thành công");
                return RedirectToAction("Index");
            }


        }

        public ActionResult MomoCallBack(string amount, string extraData, string signature)
        {
            string[] words = extraData.Split(',');

            var user = ApiService.GetIdLogin(words[2]);

            if (ApiService.AcceptOrder(new OrderVipDTO()
            {
                PVipID = Int32.Parse(words[0]),
                PaymentID = Int32.Parse(words[1]),
                UserID = user.ID,
                OrdPrice = Int32.Parse(amount)
            }))
            {
                SetAlert("Mua gói vip thành công", "success");
                return RedirectToAction("Success", "Payment",new {code = signature });
            }


            SetAlert("Mua gói vip thành công", "mua gói vip không thành công");
            return RedirectToAction("Index");


        }


        public ActionResult Success(string code)
        {
            return View();
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