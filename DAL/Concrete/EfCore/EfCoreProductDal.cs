using CORE.Entities;
using DAL.Abstract;
using DAL.Context;
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
    }
}
