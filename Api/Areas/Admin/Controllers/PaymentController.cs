using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Models;
using ModelViews.DTOs;

namespace Api.Areas.Admin.Controllers
{
    public class PaymentController : ApiController
    {
        // GET: api/Payment
        public IEnumerable<PaymentDTO> Get()
        {
            return new Repositories().GetAllPayment();
        }

        // GET: api/Payment/5
        public PaymentDTO Get(int id)
        {
           return new Repositories().GetPaymentById(id);
        }

        // POST: api/Payment
        public IHttpActionResult Post([FromBody]PaymentDTO payment)
        {
            var res = new Repositories().CreatePayment(payment);
            if (res)
            {
                return Ok();
            }
            return InternalServerError();
        }

        // PUT: api/Payment/5
        public IHttpActionResult Put(int id,[FromBody]PaymentDTO payment)
        {
            var res = new Repositories().UpdatePayment(payment);
            if (res)
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE: api/Payment/5
        public IHttpActionResult Delete(int id)
        {
            var res = new Repositories().DeletePayment(id);
            if (res)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
