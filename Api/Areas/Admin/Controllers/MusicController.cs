using Api.Models;
using ModelViews.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Api.Areas.Admin.Controllers
{
    [RoutePrefix("api/music")]
    public class MusicController : ApiController
    {
        // GET: api/Music
        public IEnumerable<MusicDTO> Get()
        {
            return new Repositories().GetAllMusic().ToList();
        }

        // GET: api/Music/5
        public MusicDTO Get(int id)
        {
            var data = new Repositories().GetMusicById(id);
            return data;
        }

        // POST: api/Music
        public void Post([FromBody]MusicDTO music)
        {
            new Repositories().CreateMusic(music);
        }

        // PUT: api/Music/5
        public void Put(int id, [FromBody]MusicDTO music)
        {
            new Repositories().UpdateMusic(music);
        }

        // DELETE: api/Music/5
        public void Delete(int id)
        {
            new Repositories().DeleteMusic(id);
        }

        //// DELETE: api/Music/GetMusicByName/Godzila
        [Route("GetMusicByName/{key}")]
        public IHttpActionResult GetMusicByName(string key)
        {
            var data = new Repositories().GetMusicByKey(key);
            if (data == null)
            {
                return NotFound(); // Returns a NotFoundResult
            }
            return Ok(data);
        }

        [HttpGet, Route("GetMusicPaging")]
        public IEnumerable<MusicDTO> GetMusicPaging([FromBody]Pagination pagination)
        {
            return new Repositories().GetListMusicByPage(pagination).ToList();
        }
    }
}