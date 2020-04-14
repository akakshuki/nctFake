using Api.Models.Dao;
using Api.Models.EF;
using System.Collections.Generic;
using System.Linq;
using ModelViews.DTOs;

namespace Api.Models.Bus
{
    public class CategoryBus
    {
        public IEnumerable<Category> GetAllCate()
        {
            var data = new CategoryDao().GetAllCate().Where(s => s.ID_root == null).Select(s => new Category
            {
                ID = s.ID,
                CateName = s.CateName,
            });
            return data;
        }
        public IEnumerable<Category> GetAllCateCon()
        {
            var data = new CategoryDao().GetAllCate().Select(s => new Category
            {
                ID = s.ID,
                CateName = s.CateName,
                ID_root = s.ID_root
            });
            return data;
        }

        public IEnumerable<CategoryDTO> GetAllListCategories()
        {
            var data = new CategoryDao().GetAllCate().Select(s => new CategoryDTO()
            {
                ID = s.ID,
                CateName = s.CateName,
                ID_root = s.ID_root,
  //              CategoryRootName = new CategoryDao().GetCateById(s.ID_root).CateName
            });
            return data;
        }

        public Category GetCateById(int id)
        {
            var data = new CategoryDao().GetCateById(id);
            return new Category
            {
                ID = data.ID,
                CateName = data.CateName,
                ID_root = data.ID_root
            };
        }
        public IEnumerable<Category> GetCateByIdRoot(int id)
        {
            var data = new CategoryDao().GetCateByIdRoot(id).Select(s => new Category
            {
                ID = s.ID,
                CateName = s.CateName,
                ID_root = s.ID_root

            });
            return data;
        }
        public bool CreateCate(Category category)
        {
            if (new CategoryDao().CreateCate(category))
            {
                return true;
            }
            return false;
        }

        public bool UpdateCate(Category category)
        {
            if (new CategoryDao().UpdateCate(category))
            {
                return true;
            }
            return false;
        }

        public bool DeleteCate(int id)
        {
            if (new CategoryDao().DeleteCate(id))
            {
                return true;
            }
            return false;
        }
    }
}