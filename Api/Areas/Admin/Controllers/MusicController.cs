﻿using System;
using Api.Models;
using ModelViews.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Api.Areas.Admin.Controllers
{
    [System.Web.Http.RoutePrefix("api/music")]
    public class MusicController : ApiController
    {
        // GET: api/Music
        public IEnumerable<MusicDTO> Get()
        {
            var data = new Repositories().GetAllMusic().ToList();
            return data;
        }

        // GET: api/Music/5
        public MusicDTO Get(int id)
        {
            var data = new Repositories().GetMusicById(id);
            return data;
        }

        // POST: api/Music
        public IHttpActionResult Post([FromBody]MusicDTO music)
        {
            var httpContext = HttpContext.Current;

            try
            {
                new Repositories().CreateMusic(music);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return InternalServerError();
            }
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

        [HttpPost, Route("GetMusicPaging")]
        public IEnumerable<MusicDTO> GetMusicPaging([FromBody]Pagination pagination)
        {
            return new Repositories().GetListMusicByPage(pagination).ToList();
        }
        [HttpGet, Route("GetSingerMusicByMusicId/{id}")]
        public IEnumerable<SingerMusicDTO> GetSingerMusicByMusicId(int id)
        {
            return new Repositories().SingerMusicByMusicId(id).ToList();
        }
        [HttpDelete, Route("DeleteSingerMusicByMusicId/{id}")]
        public IHttpActionResult DeleteSingerMusicByMusicId(int id)
        {
            var res = new Repositories().DeleteSingerMusic(id);
            if (res)
            {
                return Ok();
            }

            return NotFound();
        }
        [System.Web.Http.HttpPost, Route("AddSingerToMusic")]
        public IHttpActionResult AddSingerToMusic([FromBody] SingerMusicDTO singerMusic)
        {
            try
            {
                new Repositories().AddSingerToMusic(singerMusic);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return InternalServerError();
            }
        }
    }
}