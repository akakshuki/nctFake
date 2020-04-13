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
    [RoutePrefix("api/PlaylistMusic")]
    public class PlaylistMusicController : ApiController
    {
        // GET api/<controller>
        [Route("GetMusicByIdPlaylist/{id}")]
        public IEnumerable<PlaylistMusicDTO> GetMusicByIdPlaylist(int id)
        {
            var data = new Repositories().GetMusicByIdPlaylist(id);
            return data;
        }

        // GET api/<controller>/5
        [Route("DeletePlaylistMusic/{id}")]
        public IHttpActionResult DeletePlaylistMusic(int id)
        {
            if (new Repositories().DeletePlaylistMusic(id))
            {
                return Ok();
            }
            return InternalServerError();
        }

        // POST api/<controller>
        [Route("CreatePlaylistMusic")]
        public IHttpActionResult CreatePlaylistMusic(PlaylistMusic playlistMusic)
        {
            if (new Repositories().CreatePlaylistMusic(playlistMusic))
            {
                return Ok();
            }
            return InternalServerError();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}