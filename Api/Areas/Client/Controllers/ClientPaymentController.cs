using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Models;
using ModelViews.DTOs;

namespace Api.Areas.Client.Controllers
{
    [RoutePrefix("api/ClientPayment")]
    public class ClientPaymentController : ApiController
    {
        // GET: api/ClientPayment
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ClientPayment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ClientPayment
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ClientPayment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ClientPayment/5
        public void Delete(int id)
        {
        }

        [HttpPost, Route("AcceptPayment")]
        public IHttpActionResult AcceptPayment([FromBody] OrderVipDTO dto)
        {
            if (new Repositories().AcceptOrderVip(dto)) return Ok();
            return NotFound();
        }
    }
}
