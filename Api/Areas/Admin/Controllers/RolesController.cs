using Api.Models.EF;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Api.Controllers
{
    public class RolesController : ApiController
    {
        private ProjectNCTEntities db = new ProjectNCTEntities();

        // GET: api/Roles
        public IEnumerable<Role> GetRoles()
        {
            try
            {
                return db.Roles;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}