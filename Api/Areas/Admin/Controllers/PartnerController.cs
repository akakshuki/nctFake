using Api.Models;
using Api.Models.EF;
using ModelViews.DTOs;
using System.Collections.Generic;
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
        [Route("GetPartnerById/{id}")]
        public Partner GetPartnerById(int id)
        {
            return new Repositories().GetPartnerById(id);
        }

        // POST api/<controller>
        [Route("CreatePartner")]
        public IHttpActionResult CreatePartner(PartnerDTO partner)
        {
            if (new Repositories().CreatePartner(partner))
            {
                return Ok();
            }
            return InternalServerError();
        }

        // PUT api/<controller>/5
        [Route("UpdatePartner")]
        public IHttpActionResult UpdatePartner(PartnerDTO partner)
        {
            if (new Repositories().UpdatePartner(partner))
            {
                return Ok();
            }
            return InternalServerError();
        }

        [Route("DeletePartner/{id}")]
        public IHttpActionResult DeletePartner(int id)
        {
            if (new Repositories().DeletePartner(id))
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}