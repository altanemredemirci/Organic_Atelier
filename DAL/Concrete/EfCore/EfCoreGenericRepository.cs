using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Concrete.EfCore
{
    public class EfCoreGenericRepository<T,TContext> where T:class where TContext:DbContext
    {
        private readonly TContext _context;

        public EfCoreGenericRepository(TContext context)
        {
            _context = context;
        }

        public virtual List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual List<T> GetAll(Expression<Func<T,bool>> filter = null)
        {
            var entities = _context.Set<T>().AsQueryable();

            if (filter != null)
            {
                entities = entities.Where(filter);
            }

            return entities.ToList();
        }

        public virtual T GetOne(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual int Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }

        public virtual int Update()
        {
            return _context.SaveChanges();
        }

        public virtual int Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);

            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }           
           
            return _context.SaveChanges();
        }
    }
}
