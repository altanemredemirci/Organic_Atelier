using DAL.Concrete.EfCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete
{
    public class ProductService
    {
        private readonly EfCoreProductDal _efCoreProductDal;

        public ProductService(EfCoreProductDal efCoreProductDal)
        {
            _efCoreProductDal = efCoreProductDal;
        }
    }
}
