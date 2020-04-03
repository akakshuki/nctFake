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
    [RoutePrefix("api/Partner")]
    public class PartnerController : ApiController
    {
        [Route("GetAllPartner")]
        public IEnumerable<Partner> GetAllPartner()
        {
            return new Repositories().GetAllPartner();
        }
        // POST api/<controller>
        [Route("CreatePartner")]
        public IHttpActionResult CreatePartner(Partner partner)
        {
            if (new Repositories().CreatePartner(partner))
            {
                return Ok();
            }
            return InternalServerError();
        }
        // PUT api/<controller>/5
        [Route("UpdatePartner")]
        public IHttpActionResult UpdatePartner(Partner partner)
        {
            if (new Repositories().UpdatePartner(partner))
            {
                return Ok();
            }
            return InternalServerError();
        }

    }
}