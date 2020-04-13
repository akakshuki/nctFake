using Api.Models;
using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Areas.Admin.Controllers
{
    [RoutePrefix("api/OrderVip")]
    public class OrderVipController : ApiController
    {
        // GET api/<controller>
        [Route("GetOrderVipByIdUser/{id}")]
        public IEnumerable<OrderVipDTO> GetOrderVipByIdUser(int id)
        {
            var data = new Repositories().GetOrderVipByIdUser(id);
            return data;
        }

        // GET api/<controller>/5
        [HttpGet, Route("GetAllOrderVip")]
        public List<OrderVipDTO> Get()
        {
            return new Repositories().GetAllOrderVip();
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}