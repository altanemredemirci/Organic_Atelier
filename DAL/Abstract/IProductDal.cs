using CORE.Entities;
using CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Abstract
{
    public interface IProductDal : IRepositoryService<Product>
    {
        int Update(Product updateProduct, List<Image> images);
    }
}
