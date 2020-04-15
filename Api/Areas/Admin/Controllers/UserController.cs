using Api.Models;
using Api.Models.Dao;
using Api.Models.EF;
using ModelViews.DTOs;
using System.Collections.Generic;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("{email:string}")]
        public UserDTO GetIdLogin([FromBody]string email)
        {
            var data = new UserDao().GetIdLogin(email);
            return data;
        }
        [HttpGet,Route("Login/{email}/{passWord}")]
        public int Login(string email, string passWord) 
        {
            var data = new UserDao().Login(email, passWord);
            return data;
        }
        // GET api/<controller>
        [Route("GetAllUserNormal")]
        public IEnumerable<User> GetAllUserNormal()
        {
            return new Repositories().GetAllUserNormal();
        }
        // GET api/<controller>
        [Route("GetAllUserVip")]
        public IEnumerable<User> GetAllUserVip()
        {
            return new Repositories().GetAllUserVip();
        }

        // GET api/<controller>
        [Route("GetAllSinger")]
        public IEnumerable<User> GetAllSinger()
        {
            var data = new Repositories().GetAllSinger();
            return data;
        }

        // GET api/<controller>/5
        [Route("GetUserById/{id}")]
        public UserDTO GetUserById(int id)
        {
            return new Repositories().GetUserById(id);
        }

        [Route("GetUserByIdRole/{id}")]
        public IEnumerable<User> GetUserByIdRole(int id)
        {
            return new Repositories().GetUserByIdRole(id);
        }

        // POST api/<controller>
        [Route("CreateSinger")]
        public IHttpActionResult CreateSinger(UserDTO userDTO)
        {
            if (new Repositories().CreateSinger(userDTO))
            {
                return Ok();
            }
            return InternalServerError();
        }

        // POST api/<controller>
        [Route("CreateUser")]
        public IHttpActionResult CreateUser(UserDTO userDTO)
        {
            if (new Repositories().CreateUser(userDTO))
            {
                return Ok();
            }
            return InternalServerError();
        }

        // PUT api/<controller>/5
        [Route("UpdateUser")]
        public IHttpActionResult UpdateUser(User user)
        {
            if (new Repositories().UpdateUser(user))
            {
                return Ok();
            }
            return InternalServerError();
        }

        [Route("UpdateSinger")]
        public IHttpActionResult UpdateSinger(User user)
        {
            if (new Repositories().UpdateSinger(user))
            {
                return Ok();
            }
            return InternalServerError();
        }

        // DELETE api/<controller>/5
        [Route("DeleteUser/{id}")]
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