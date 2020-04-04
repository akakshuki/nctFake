using Api.Models.Dao;
using Api.Models.EF;

namespace Api.Models.Bus
{
    public class RoleBus
    {
        public Role GetRoleByID(int id)
        {
            var data = new RoleDao().GetRoleById(id);
            return new Role
            {
                RoleName = data.RoleName
            };
        }
    }
}