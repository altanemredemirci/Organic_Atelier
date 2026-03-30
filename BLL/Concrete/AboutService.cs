using BLL.Abstract;
using CORE.Entities;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutService(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public About GetOne()
        {
            return _aboutDal.GetOne();
        }
    }
}
