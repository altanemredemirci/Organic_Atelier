using BLL.Abstract;
using CORE.Entities;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal=categoryDal;
        }
        public int Create(Category entity)
        {
            return _categoryDal.Create(entity);
        }

        public int Delete(int id)
        {
            return _categoryDal.Delete(id);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetAll(filter);
        }

        public Category GetOne(int id)
        {
            return _categoryDal.GetOne(id);
        }

        public int Update()
        {
            return _categoryDal.Update();
        }
    }
}
