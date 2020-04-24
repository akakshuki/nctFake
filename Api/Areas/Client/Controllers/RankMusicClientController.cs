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
    public class RankMusicClientController : ApiController
    {
        // GET: api/RankMusicClient
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RankMusicClient/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(new Repositories().GetListRankThisWeek().Where(x=>x.CateID == id).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               return NotFound();
            }
        }

        // POST: api/RankMusicClient
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RankMusicClient/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RankMusicClient/5
        public void Delete(int id)
        {
        }
    }
}
