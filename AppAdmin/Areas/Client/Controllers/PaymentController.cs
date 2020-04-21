using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PayPal.Api;
using System.Web;
using System.Web.Mvc;
using AppAdmin.Areas.Client.Models;
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
            var idPackageVip = (int)TempData["PackageVipId"];
            var idPaymentGate = idPayment;
            var useData = (UserDTO)Session[Common.CommonConstants.USER_SESSION];
            var packageVip = ApiService.GetAllPackageVip().SingleOrDefault(x => x.ID == idPackageVip);
            if (idPaymentGate == 1)
            {
                // var packageVip = ApiService.GetAllPackageVip().SingleOrDefault(x => x.ID == idPackageVip);

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
            else
            {

                 Session["ordervip"] = new OrderVipDTO()
                 {
                     PVipID = idPackageVip,
                     PaymentID = idPayment,
                     UserID = useData.ID,
                     OrdPrice = packageVip.PVipPrice
                 };
                return RedirectToAction("PaymentWithPaypal", "Payment");
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
                return RedirectToAction("Success", "Payment", new { code = signature });
            }


            SetAlert("Mua gói vip không thành công", "error");
            return RedirectToAction("Index");


        }

        //work with paypal payment
        private Payment payment;

        //create a payment using an APIContext
        private Payment CreatePayment(APIContext apiContext, string redirectUrl, OrderVipDTO order)
        {
            var lsItem = new ItemList() { items = new List<Item>() };
            var data = ApiService.GetPackageVipById((int)order.PVipID);
            var money = ((data.PVipPrice / 23000));
            lsItem.items.Add(new Item { name = data.PVipName, currency = "USD", price = (data.PVipPrice/23000).ToString(), quantity = "1", sku = "sku" });
          

            var payer = new Payer()
            {
                payment_method = "paypal",
                payer_info = new PayerInfo
                {
                    email = "sb-v2sgo1168479@personal.example.com"
                }

            };
            var redictUrl = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };
            
            var detail = new Details() { tax = "1", shipping = "1", subtotal = money.ToString() }; //subtotal : total order, note: sum(price*quantity)
            var amount = new Amount() { currency = "USD", details = detail, total = (money+2).ToString() }; //total= tax + shipping + subtotal
            var transList = new List<Transaction>();
            transList.Add(new Transaction
            {
                description = "Hotel Management using Paypal",
                invoice_number = Convert.ToString((new Random()).Next(100000)),
                amount = amount,
                item_list = lsItem,

            });
            this.payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transList,
                redirect_urls = redictUrl
            };
            return this.payment.Create(apiContext);
        }
        //create execute payment method
        private Payment ExecutePayment(APIContext apiContext, string payerID, string paymentID)
        {
            var paymentExecute = new PaymentExecution() { payer_id = payerID };
            this.payment = new Payment() { id = paymentID };
            return this.payment.Execute(apiContext, paymentExecute);
        }
        //create method
        public ActionResult PaymentWithPaypal()
        {
            APIContext apiContext = PaypalConfiguration.GetAPIContext();

            var order = (OrderVipDTO) Session["ordervip"];
            try
            {
                string payerID = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerID))
                {
                    //create a payment
                    string baseUri = Request.Url.Scheme + "://" + Request.Url.Authority + "/Client/Payment/PaymentWithPaypal?guid=";
                    string guid = Convert.ToString((new Random()).Next(100000));
                    var createdPayment = CreatePayment(apiContext, baseUri + guid, order);

                    var link = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = string.Empty;
                    while (link.MoveNext())
                    {
                        Links links = link.Current;
                        if (links.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = links.href;
                        }
                    }
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    var guid = Request.Params["guid"];
                    var executePayment = ExecutePayment(apiContext, payerID, Session[guid] as string);
                    if (executePayment.state.ToLower() != "approved")
                    {
                        SetAlert("Mua gói vip không thành công", "error");
                        return RedirectToAction("Index");

                    }
                }
            }
            catch (PayPal.PaymentsException ex)
            {
                PaypalLogger.Log("Error: " + ex.Message);
                SetAlert("Mua gói vip không thành công", "error");
                return RedirectToAction("Index");

            }

            ApiService.AcceptOrder(order);
            SetAlert("Mua gói vip thành công", "success");
            return RedirectToAction("Success", "Payment", new { code = apiContext.AccessToken });

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