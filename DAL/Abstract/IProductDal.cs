using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Abstract
{
    public interface IProductDal
    {
        List<Product> GetAll();
        List<Product> GetAll(Expression<Func<Product, bool>> filter = null);
        Product GetOne(int id);
        int Create(Product entity);
        int Update();
        int Delete(int id);
    }
}
