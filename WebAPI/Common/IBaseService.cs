using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPI.Common
{
    public interface IBaseService<T> where T : class
    {
        Task Insert(T o);

        IQueryable<T> GetAll(string s = "");
        Task<IList<T>> GetAllAsync(string s = "");

        IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task<IList<T>> GetAsync(Expression<Func<T, bool>> filter = null, string includeProperties = "");

        T GetByID(object ID);

        Task Update(T o);

        Task Update(object primaryKey, T o);

        Task Delete(T o);

        Task Delete(object primaryKey);
        Task Delete(Expression<Func<T, bool>> filter = null, string includeProperties = "");

        IQueryable<T> GetWithPaging(Expression<Func<T, bool>> filter = null, string includeProperties = "", int take = default(int), int skip = default(int));
        Task<IList<T>> GetWithPagingAsync(Expression<Func<T, bool>> filter = null, string includeProperties = "", int take = default(int), int skip = default(int));
    }
}