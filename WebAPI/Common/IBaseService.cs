using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebAPI.Common
{
    public interface IBaseService<T> where T : class
    {
        void Insert(T o);

        IQueryable<T> GetAll(string includeProperties = "");

        IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
            string includeProperties = "");

        T GetByID(object ID);

        void Update(T o);

        void Update(object primaryKey, T o);

        void Delete(T o);

        void Delete(object primaryKey);

        void Delete(Expression<Func<T, bool>> filter);

        IQueryable<T> GetWithPaging(Expression<Func<T, bool>> filter = null, string includeProperties = "", int take = default(int), int skip = default(int));
    }
}