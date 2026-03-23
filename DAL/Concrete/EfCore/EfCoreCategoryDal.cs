using CORE.Entities;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete.EfCore
{
    public class EfCoreCategoryDal:EfCoreGenericRepository<Category,DataContext>
    {
        private readonly DataContext _context;

        public EfCoreCategoryDal(DataContext context):base(context)
        {
            _context = context;
        }

        public Category GetByCategoryId(int id)
        {
            return _context.Categories.Where(i => i.Id == id).Include(i => i.Products).FirstOrDefault();
        }
    }
}
