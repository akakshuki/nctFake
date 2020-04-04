using Api.Models.EF;
using System.Linq;

namespace Api.Models.Dao
{
    public class RoleDao
    {
        private ProjectNCTEntities db = null;

        public RoleDao()
        {
            db = new ProjectNCTEntities();
        }

        public Role GetRoleById(int id)
        {
            var data = db.Roles.SingleOrDefault(s => s.ID == id);
            return data;
        }
    }
}