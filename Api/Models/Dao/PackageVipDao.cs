using Api.Models.EF;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Api.Models.Dao
{
    public class PackageVipDao
    {
        private ProjectNCTEntities db = null;

        public PackageVipDao()
        {
            db = new ProjectNCTEntities();
        }

        public PackageVip CreatePackageVip(PackageVip packageVip)
        {
            db.PackageVips.Add(packageVip);
            db.SaveChanges();
            return packageVip;
        }

        //delete
        public void Delete(int id)
        {
            var data = db.PackageVips.Find(id);
            if (data != null)
            {
                db.PackageVips.Remove(data);
                db.SaveChanges();
            }
        }

        //update
        public void Update(PackageVip packageVip)
        {
            db.Entry(packageVip).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<PackageVip> GetAll()
        {
            return db.PackageVips.ToList();
        }

        public PackageVip GetById(int id)
        {
            return db.PackageVips.Find(id);
        }
    }
}