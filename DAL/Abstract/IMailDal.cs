using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abstract
{
    public interface IMailDal
    {
        int SendMail(string mail);
    }
}
