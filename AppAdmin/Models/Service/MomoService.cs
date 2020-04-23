using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MomoGateWay;
using MomoGateWay.DTO;
using MomoGateWay.Model;
using Newtonsoft.Json.Linq;

namespace AppAdmin.Models.Service
{
    public class MomoService
    {
    
        public object SetOrderByMomo(Guid orderNo, decimal money, int idPackagevip, int payment, string email)
        {

            var jsonRequesy = new JsonRequest()
            {
                ApiEndPoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor",
                PartnerCode = "MOMOVYHR20200208",
                AccessKey = "dIn9mqdLZF6htCr5",
                RequestId = Guid.NewGuid().ToString(),
                Amount = ((int)money).ToString(),
                OrderId = orderNo.ToString(),
                OrderInfo = "Thanh toán gói vip nghe nhạc",
                ReturnUrl = "https://localhost:44315/Client/Payment/MomoCallBack/",
                NotifyUrl = "https://localhost:5001/api/",
                RequestType = "captureMoMoWallet",
                SecretKey = "iI0Fg6R7nJUzpda4qbsYd4iFQHE9HDny",
                Signature = "",
                ExtraData = idPackagevip.ToString()+","+payment+","+email 
            };

            string rawHash = "partnerCode=" +
                             jsonRequesy.PartnerCode + "&accessKey=" +
                             jsonRequesy.AccessKey + "&requestId=" +
                             jsonRequesy.RequestId + "&amount=" +
                             jsonRequesy.Amount + "&orderId=" +
                             jsonRequesy.OrderId + "&orderInfo=" +
                             jsonRequesy.OrderInfo + "&returnUrl=" +
                             jsonRequesy.ReturnUrl + "&notifyUrl=" +
                             jsonRequesy.NotifyUrl + "&extraData=" +
                             jsonRequesy.ExtraData;



            string signature = new MoMoSecurity().signSHA256(rawHash, jsonRequesy.SecretKey);


            JObject message = new JObject
            {
                { "partnerCode", jsonRequesy.PartnerCode },
                { "accessKey", jsonRequesy.AccessKey },
                { "requestId", jsonRequesy.RequestId },
                { "amount", jsonRequesy.Amount },
                { "orderId", jsonRequesy.OrderId },
                { "orderInfo", jsonRequesy.OrderInfo },
                { "returnUrl", jsonRequesy.ReturnUrl },
                { "notifyUrl", jsonRequesy.NotifyUrl },
                { "extraData", jsonRequesy.ExtraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(jsonRequesy.ApiEndPoint, message.ToString());
            JObject jmessage = JObject.Parse(responseFromMomo);
            return jmessage.GetValue("payUrl").ToString();
        }
    }
}