﻿using Api.Models;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Areas.Client.Controllers
{
    [RoutePrefix("api/QualityMusicClient")]
    public class QualityMusicClientController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [Route("GetQualityMusicByIdMusic/{id}")]
        public QualityMusicDTO GetQualityMusicByIdMusic(int id)
        {
            var data = new Repositories().GetQualityMusicByIdMusic(id);
            return data;
        }
        // GET api/<controller>/5
        [Route("GetQualityMusicByIdMusicMV/{id}")]
        public QualityMusicDTO GetQualityMusicByIdMusicMV(int id)
        {
            var data = new Repositories().GetQualityMusicByIdMusicMV(id);
            return data;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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