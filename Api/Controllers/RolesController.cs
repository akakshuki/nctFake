using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Api.Models.Dao;
using Api.Models.EF;


namespace Api.Controllers
{
   
    public class RolesController : ApiController
    {
     
        // GET: api/Roles
        public IEnumerable<Role> GetRoles()
        {
            try
            {
                
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
}