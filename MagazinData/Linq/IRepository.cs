using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MagazinData

{
    public interface IRepository<T>
    {

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll();
        void Delete(IEnumerable<T> entities);
        IQueryable<T> Query(Expression<Func<T, bool>> expression);
        IQueryable<T> Query();
        T GetById(int id);
        T GetByName(string id);

    }
}
