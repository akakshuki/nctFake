using Api.Models.EF;
using System.Collections.Generic;
using System.Linq;

namespace Api.Models.Dao
{
    public class CategoryDao
    {
        private ProjectNCTEntities db = null;

        public CategoryDao()
        {
            db = new ProjectNCTEntities();
        }

        public List<Category> GetAllCate()
        {
            return db.Categories.ToList();
        }

        public Category GetCateById(int id)
        {
            var data = db.Categories.SingleOrDefault(s => s.ID == id);
            return data;
        }

        public bool CreateCate(Category category)
        {
            db.Categories.Add(category);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateCate(Category category)
        {
            var data = db.Categories.SingleOrDefault(s => s.ID == category.ID);
            data.CateName = category.CateName;
            data.ID_root = category.ID_root;
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteCate(int id)
        {
            var data = db.Categories.SingleOrDefault(s => s.ID == id);
            db.Categories.Remove(data);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}