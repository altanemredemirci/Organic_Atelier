using CORE.Entities;
using DAL.Abstract;
using DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete.EfCore
{
    public class EfCoreAboutDal : IAboutDal
    {
        private readonly DataContext _context;

        public EfCoreAboutDal(DataContext context)
        {
            _context = context;
        }
        public About GetOne()
        {
            return _context.Abouts.FirstOrDefault();
        }
    }
}
