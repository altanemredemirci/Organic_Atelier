using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abstract
{
    public interface IContactDal
    {
        Contact GetById();
    }
}
