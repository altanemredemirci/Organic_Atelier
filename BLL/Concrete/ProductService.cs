using BLL.Abstract;
using CORE.Entities;
using DAL.Abstract;
using DAL.Concrete.EfCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Concrete
{
    public class ProductService:IProductService
    {
        private readonly IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public int Create(Product entity)
        {
            return _productDal.Create(entity);
        }

        public int Delete(int id)
        {
            return _productDal.Delete(id);
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.GetAll(filter);
        }

        public Product GetOne(int id)
        {
            return _productDal.GetOne(id);
        }

        public int Update(Product updateProduct, List<Image> images)
        {
            return _productDal.Update(updateProduct, images);
        }

        public int Update()
        {
            throw new NotImplementedException();
        }
    }
}
