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
    public class QualityController : ApiController
    {
        // GET: api/Quality
        public IEnumerable<QualityDTO> Get()
        {
           return new Repositories().GetAllQuality();
        }

        // GET: api/Quality/5
        public QualityDTO Get(int id)
        {
            return new Repositories().GetQualityById(id);
        }

        // POST: api/Quality
        public IHttpActionResult Post([FromBody]QualityDTO quality)
        {
            var res = new Repositories().CreateQuality(quality);
            if (res)
            {
                return Ok();
            }

            return InternalServerError();
        }

        // PUT: api/Quality/5
        public IHttpActionResult Put(int id, [FromBody]QualityDTO quality)
        {
            var res = new Repositories().UpdateQuality(quality);
            if (res)
            {
                return Ok();
            }

            return NotFound();
        }

        // DELETE: api/Quality/5
        public IHttpActionResult Delete(int id)
        {
            var res = new Repositories().DeleteQuality(id);
            if (res)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
