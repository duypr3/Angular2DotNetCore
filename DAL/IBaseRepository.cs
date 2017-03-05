using System;
using System.Linq;
using System.Linq.Expressions;

namespace DAL
{
    public interface IBaseRepository<T>
    {
        void Insert(T o);

        IQueryable<T> GetAll(string s);

        IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
            string includeProperties = "");

        T GetByID(object ID);

        void Update(T o);

        void Update(object primaryKey, T o);

        void Delete(T o);

        void Delete(object primaryKey);
        void Delete(Expression<Func<T, bool>> filter);
    }
}