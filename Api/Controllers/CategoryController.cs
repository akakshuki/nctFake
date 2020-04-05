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
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        // GET api/<controller>
        [Route("GetAllCate")]
        public IEnumerable<Category> GetAllCate()
        {
            return new Repositories().GetAllCate();
        }

        // GET api/<controller>/5
        [Route("GetCateById/{id}")]
        public Category GetCateById(int id)
        {
            return new Repositories().GetCateById(id);
        }

        [Route("GetRoleById/{id}")]
        public Role GetRoleById(int id)
        {
            return new Repositories().GetRoleById(id);
        }

        [Route("GetCateByIdRoot/{id}")]
        public IEnumerable<Category> GetCateByIdRoot(int id)
        {
            return new Repositories().GetCateByIdRoot(id);
        }

        // POST api/<controller>
        [Route("CreateCate")]
        public IHttpActionResult CreateCate(Category category)
        {
            if (new Repositories().CreateCate(category))
            {
                return Ok();
            }
            return InternalServerError();
        }

        [Route("UpdateCate")]
        public IHttpActionResult UpdateCate(Category category)
        {
            if (new Repositories().UpdateCate(category))
            {
                return Ok();
            }
            return InternalServerError();
        }

        [Route("DeleteCate/{id}")]
        public IHttpActionResult DeleteCate(int id)
        {
            if (new Repositories().DeleteCate(id))
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}