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
    [RoutePrefix("api/UserClient")]
    public class UserClientController : ApiController
    {
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet,Route("UserCheckVipEnd/{email}")]
        public IHttpActionResult UserCheckVipEnd(string email)
        {
            try
            {
                new Repositories().UserCheckVipEnd(email);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
       
        // POST: api/User
        [HttpPost,Route("UserResetPassword")]
        public IHttpActionResult UserResetPassword([FromBody]UserDTO userDto)
        {
            try
            {
                new Repositories().UserResetPassword(userDto);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
