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
using Api.Models.EF;

namespace Api.Controllers
{
    public class RolesController : ApiController
    {
        private ProjectNCTEntities db = null;


        public RolesController()
        {
            db = new ProjectNCTEntities();
        }

        // GET: api/Roles
        public IEnumerable<Role> GetRoles()
        {
            try
            {
                var data = db.Roles.ToList();
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
}