using Api.Models;
using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Areas.Admin.Controllers
{
    [RoutePrefix("api/LyricsMusic")]
    public class LyricsMusicController : ApiController
    {
        // GET api/<controller>
        [Route("GetLyricByIdMusic/{id}")]
        public LyricsMusicDTO GetLyricByIdMusic(int id)
        {
            var data = new Repositories().GetLyricByIdMusic(id);
            return data;
        }
        [Route("GetLyricById/{id}")]
        public LyricsMusicDTO GetLyricById(int id)
        {
            var data = new Repositories().GetLyricById(id);
            return data;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [Route("Create")]
        public IHttpActionResult Create(LyricsMusic lyricsMusic)
        {
            if (new Repositories().CreateLyrics(lyricsMusic))
            {
                return Ok();
            }
            return InternalServerError();
        }

        // PUT api/<controller>/5
        [Route("Update")]
        public IHttpActionResult Update(LyricsMusic lyricsMusic)
        {
            if (new Repositories().UpdateLyrics(lyricsMusic))
            {
                return Ok();
            }
            return InternalServerError();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}