using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CORE.Repositories
{
    public interface IRepositoryService<T> //GenericType
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetOne(int id);
        int Create(T entity);
        int Update();
        int Delete(int id);
    }
}
