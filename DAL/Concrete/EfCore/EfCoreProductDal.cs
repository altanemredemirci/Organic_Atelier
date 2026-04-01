using CORE.Entities;
using DAL.Abstract;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Concrete.EfCore
{
    public class EfCoreProductDal : EfCoreGenericRepository<Product,DataContext>, IProductDal
    {
        private readonly DataContext _context;

        public EfCoreProductDal(DataContext context):base(context)
        {
            _context=context;
        }

        public override Product GetOne(int id)
        {
            return _context.Products.Include(i => i.Category).Include(i => i.Images).FirstOrDefault(i => i.Id == id);
        }

        public override List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            var entities = _context.Products.Include(i=> i.Category).Include(i=> i.Images).AsQueryable();

            if (filter != null) 
            {
                entities = entities.Where(filter);
            }

            return entities.ToList();
        }

        public int Update(Product updateProduct, List<Image> images)
        {
            _context.Images.RemoveRange(images);
            var product = GetOne(updateProduct.Id);

            product.Name = updateProduct.Name;
            product.ListPrice = updateProduct.ListPrice;
            product.CategoryId = updateProduct.CategoryId;
            product.Description = updateProduct.Description;
            product.Stock = updateProduct.Stock;
            product.Discount = updateProduct.Discount;
            product.Images = updateProduct.Images;
            product.IsFavorite = updateProduct.IsFavorite;

            return _context.SaveChanges();
        }
    }
}
