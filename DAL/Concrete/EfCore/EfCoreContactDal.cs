using CORE.Entities;
using DAL.Abstract;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete.EfCore
{
    public class EfCoreContactDal : IContactDal
    {
        private readonly DataContext _context;

        public EfCoreContactDal(DataContext context)
        {
            _context = context;
        }

        public Contact GetById()
        {
            return _context.Contacts.Include(i=> i.SocialMedias).FirstOrDefault();
        }
    }
}
