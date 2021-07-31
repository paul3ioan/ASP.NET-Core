using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace MagazinData
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly DepozitContext _depozitContext;
        private readonly DbSet<T> _dbSet;
        public Repository(DepozitContext depozitContext)
        {
            _depozitContext = depozitContext;
            _dbSet = depozitContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T GetByName(string id)
        {
            return _dbSet.Find(id);
        }

        public T GetById(int id)
        {
            
            return _dbSet.Find(id);
            
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking().AsQueryable();
            // elim AsNo after web part;
        }

        public IQueryable<T> Query()
        {
            return _dbSet.AsQueryable();
        }

        public void Update(T entity)
        {
            
                _dbSet.Attach(entity);          
            _depozitContext.Entry(entity).State = EntityState.Modified;
            
        }
    }


}
