using BLL.Abstract;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete
{
    public class MailService : IMailService
    {
        private readonly IMailDal _mailDal;

        public MailService(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        public int SendMail(string mail)
        {
            return _mailDal.SendMail(mail);
        }
    }
}
