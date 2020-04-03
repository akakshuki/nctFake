using Api.Models;
using Api.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        // GET api/<controller>
        [Route("GetAllUser")]
        public IEnumerable<User> GetAllUser()
        {
            return new Repositories().GetAllUser();
        }

        // GET api/<controller>/5
        [Route("GetUserById")]
        public User GetUserById(int id)
        {
            return new Repositories().GetUserById(id);
        }
        [Route("GetUserByIdRole")]
        public IEnumerable<User> GetUserByIdRole(int id)
        {
            return new Repositories().GetUserByIdRole(id);
        }

        // POST api/<controller>
        [Route("CreateSinger")]
        public IHttpActionResult CreateSinger(User user)
        {
            if (new Repositories().CreateSinger(user))
            {
                return Ok();
            }
            return InternalServerError();
        }

        // POST api/<controller>
        [Route("CreateUser")]
        public IHttpActionResult CreateUser(User user)
        {
            if (new Repositories().CreateUser(user))
            {
                return Ok();
            }
            return InternalServerError();
        }

        // PUT api/<controller>/5
        [Route("UpdateCate")]
        public IHttpActionResult UpdateUser(User user)
        {
            if (new Repositories().UpdateUser(user))
            {
                return Ok();
            }
            return InternalServerError();
        }

        // DELETE api/<controller>/5
        [Route("DeleteCate/{id}")]
        public IHttpActionResult DeleteUser(int id)
        {
            if (new Repositories().DeleteUser(id))
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}