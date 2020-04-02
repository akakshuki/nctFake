using Api.Models.Dao;
using Api.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.Bus
{
    public class RoleBus
    {
        public Role GetRoleByID(int id)
        {
            return new RoleDao().GetRoleById(id);
        }
    }
}