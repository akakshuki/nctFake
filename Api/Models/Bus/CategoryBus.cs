using Api.Models.Dao;
using Api.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.Bus
{
    public class CategoryBus
    {
        public List<Category> GetAllCate()
        {
            return new CategoryDao().GetAllCate();
        }
        public Category GetCateById(int id)
        {
            return new CategoryDao().GetCateById(id);
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