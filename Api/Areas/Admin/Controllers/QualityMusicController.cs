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
    [RoutePrefix("api/QualityMusic")]
    public class QualityMusicController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [Route("GetQualityMusicById/{id}")]
        public QualityMusicDTO GetQualityMusicById(int id)
        {
            return new Repositories().GetQualityMusicById(id);
        }
        // GET api/<controller>/5
        [Route("GetFileByIdMusic/{id}")]
        public IEnumerable<QualityMusicDTO> GetFileByIdMusic(int id)
        {
            return new Repositories().GetFileByIdMusic(id);
        }
        // GET api/<controller>/5
        [Route("GetAllQM")]
        public IEnumerable<QualityMusicDTO> GetAllQM()
        {
            return new Repositories().GetAllQM();
        }
        // POST api/<controller>
        [Route("CreateQualityMusic")]
        public IHttpActionResult CreateQualityMusic(QualityMusicDTO qualityMusic)
        {
            if (new Repositories().CreateQualityMusic(qualityMusic))
            {
                return Ok();
            }
            return InternalServerError();
        }
        // PUT api/<controller>/5
        [Route("UpdateFile")]
        public IHttpActionResult UpdateFile(int id)
        {
            if (new Repositories().UpdateFile(id))
            {
                return Ok();
            }
            return InternalServerError();
        }

        // PUT api/<controller>/5
        [Route("UpdateQualityMusic")]
        public IHttpActionResult UpdateQualityMusic(QualityMusicDTO qualityMusic)
        {
            if (new Repositories().UpdateQualityMusic(qualityMusic))
            {
                return Ok();
            }
            return InternalServerError();
        }

        // DELETE api/<controller>/5
        [Route("DeleteQualityMusic/{id}")]
        public IHttpActionResult DeleteQualityMusic(int id)
        {
            if (new Repositories().DeleteQualityMusic(id))
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}