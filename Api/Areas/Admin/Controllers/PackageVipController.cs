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
    public class PackageVipController : ApiController
    {
        // GET: api/PackageVip
        public IEnumerable<PackageVipDTO> Get()
        {
            return new Repositories().GetAllPackageVip();
        }

        // GET: api/PackageVip/5
        public PackageVipDTO Get(int id)
        {
            return new Repositories().GetPackageVipById(id);
        }

        // POST: api/PackageVip
        public IHttpActionResult Post([FromBody]PackageVipDTO packageVip)
        {
            var res = new Repositories().CreatePackageVip(packageVip);
            if (res)
            {
                return Ok();
            }

            return InternalServerError();

        }

        // PUT: api/PackageVip/5
        public IHttpActionResult Put(int id, [FromBody]PackageVipDTO packageVip)
        {
            var res=  new Repositories().UpdatePackageVip(packageVip);
            if (res)
            {
                return Ok();
            }

            return NotFound();
        }

        // DELETE: api/PackageVip/5
        public IHttpActionResult Delete(int id)
        {
            var res = new Repositories().DeletePackageVip(id);
            if (res)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
