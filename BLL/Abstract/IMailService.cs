using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface IMailService
    {
        int SendMail(string mail);
    }
}
