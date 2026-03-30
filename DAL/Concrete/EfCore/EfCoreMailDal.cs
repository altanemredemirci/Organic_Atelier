using CORE.Entities;
using DAL.Abstract;
using DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete.EfCore
{
    public class EfCoreMailDal : IMailDal
    {
        private readonly DataContext _context;

        public EfCoreMailDal(DataContext context)
        {
            _context = context;
        }
        public int SendMail(string mail)
        {
            Mail m = new Mail();
            m.Subject = "Abonelik";
            m.IsHtml = true;
            m.From = "test.altanemre1989@gmail.com";
            m.Message = "Aylık Abonelik";
            m.To.Add(mail);
            _context.Mails.Add(m);

            return _context.SaveChanges();
        }
    }
}
