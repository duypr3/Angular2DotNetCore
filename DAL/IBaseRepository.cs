using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL
{
    public interface IBaseRepository<T>
    {
        Task Insert(T o);

        IQueryable<T> GetAll(string s);

        IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "");

        T GetByID(object ID);

        Task Update(T o);

        Task Update(object primaryKey, T o);

        Task Delete(T o);

        Task Delete(object primaryKey);
        Task Delete(Expression<Func<T, bool>> filter = null, string includeProperties = "");
    }
}