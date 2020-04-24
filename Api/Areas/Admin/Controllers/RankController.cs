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
    [RoutePrefix("api/Rank")]
    public class RankController : ApiController
    {
        // GET: api/Rank
        [HttpGet, Route("GetAllRank")]
        public IEnumerable<RankDTO> Get()
        {
            return new Repositories().GetAllRank();
        }

        [HttpGet, Route("GetAllThisWeekRank")]
        public IEnumerable<RankDTO> GetAllThisWeekRank()
        {
            return new Repositories().GetAllThisWeekRank();
        }


        [HttpGet, Route("GetListRankThisWeek")]
        public List<RankDTO> GetListRankThisWeek()
        {
            return new Repositories().GetListRankThisWeek();
        }

        // GET: api/Rank/5

        [HttpGet, Route("GetRankMusicOld/{id}")]
        public List<RankMusicDTO> GetRankMusicOld(int id)
        {
            return new Repositories().RankMusicOld(id);
        }

        // POST: api/Rank
        [HttpPost, Route("CreateRank")]
        public IHttpActionResult CreateRank([FromBody]RankDTO rank)
        {

            try
            {
                new Repositories().CreateNewRank(rank);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        // PUT: api/Rank/5

        [HttpPut, Route("UpdateRank/{id}")]
        public IHttpActionResult UpdateRank(int id, [FromBody]RankDTO rank)
        {
            try
            {
                new Repositories().UpdateNewRank(rank);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        // DELETE: api/Rank/5
        [HttpDelete, Route("DeleteRank/{id}")]
        public IHttpActionResult DeleteRank(int id)
        {
            try
            {
                new Repositories().DeleteRank(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
    }
}
