using Api.Models;
using Api.Models.EF;
using ModelViews.DTOs;
using System.Collections.Generic;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/Playlist")]
    public class PlaylistController : ApiController
    {
        [Route("GetAllPlaylist")]
        public IEnumerable<PlaylistDTO> GetAllPlaylist()
        {
            return new Repositories().GetAllPlaylist();
        }

        // GET api/<controller>/5
        [Route("GetPlaylistById/{id}")]
        public PlaylistDTO GetPlaylistById(int id)
        {
            return new Repositories().GetPlaylistById(id);
        }

        [Route("GetPlaylistByIdUser/{id}")]
        public IEnumerable<Playlist> GetPlaylistByIdUser(int id)
        {
            return new Repositories().GetPlaylistByIdUser(id);
        }

        // POST api/<controller>
        [Route("CreatePlaylist")]
        public IHttpActionResult CreatePlaylist(PlaylistDTO playlist)
        {
            if (new Repositories().CreatePlaylist(playlist))
            {
                return Ok();
            }
            return InternalServerError();
        }

        // PUT api/<controller>/5
        [Route("UpdatePlaylist")]
        public IHttpActionResult UpdatePlaylist(Playlist playlist)
        {
            if (new Repositories().UpdatePlaylist(playlist))
            {
                return Ok();
            }
            return InternalServerError();
        }

        // DELETE api/<controller>/5
        [Route("DeletePlaylist/{id}")]
        public IHttpActionResult DeletePlaylist(int id)
        {
            if (new Repositories().DeletePlaylist(id))
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}