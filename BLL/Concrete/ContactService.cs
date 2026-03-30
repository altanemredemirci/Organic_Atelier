using BLL.Abstract;
using CORE.Entities;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete
{
    public class ContactService : IContactService

    {
        private IContactDal _contactDal;

        public ContactService(IContactDal contactDal)
        {
            _contactDal = contactDal;   
        }

        public Contact GetById()
        {
            return _contactDal.GetById();
        }
    }
}
