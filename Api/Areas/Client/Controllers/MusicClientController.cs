using Api.Models;
using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Areas.Client.Controllers
{
    [RoutePrefix("api/MusicClient")]
    public class MusicClientController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("UpdateView/{id}")]
        public int UpdateView(int id)
        {
            return new Repositories().UpdateView(id);
        }
        [Route("DeleteLQ/{id}")]
        public IHttpActionResult DeleteLQ(int id)
        {
            if (new Repositories().DeleteLQ(id))
            {
                return Ok();
            }
            return InternalServerError();
        }


        [HttpGet]
        [Route("GetMusicByIdUser/{id}")]
        public List<MusicDTO> GetMusicByIdUser(int id)
        {
            return new Repositories().GetMusicByIdUser(id);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        public IHttpActionResult Post(MusicDTO s)
        {
            var item = new Music { CategoryId = s.CategoryId, ID = s.ID, MusicDayCreate = s.MusicDayCreate, MusicDownloadAllowed = s.MusicDownloadAllowed, MusicImage = s.MusicImage, MusicName = s.MusicName, MusicNameUnsigned = s.MusicNameUnsigned, MusicRelated = s.MusicRelated, SongOrMV = s.SongOrMV, UserID = s.UserID, MusicView = s.MusicView };
            var res = new Repositories().CreateMusic(item);
            if (res > 0)
            {
                return Ok(res);
            }
            return InternalServerError();
        }
    }
}