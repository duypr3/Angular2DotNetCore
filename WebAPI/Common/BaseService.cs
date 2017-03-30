using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.Common;

namespace WebAPI.Base
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        #region init

        private readonly IBaseRepository<T> _repo;

        public BaseService(IBaseRepository<T> repo)
        {
            _repo = repo;
        }

        #endregion init

        #region BaseRepository

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            return _repo.Get(filter, includeProperties);
        }

        public IQueryable<T> GetAll(string s = "")
        {
            return _repo.GetAll(s);
        }

        public T GetByID(object ID)
        {
            return _repo.GetByID(ID);
        }

        public async Task Insert(T o)
        {
            await _repo.Insert(o);
        }

        public async Task Update(T o)
        {
            await _repo.Update(o);
        }

        public async Task Update(object primaryKey, T o)
        {
            await _repo.Update(primaryKey, o);
        }

        public async Task Delete(object primaryKey)
        {
            await _repo.Delete(primaryKey);
        }

        public async Task Delete(T o)
        {
            await _repo.Delete(o);
        }

        public async Task Delete(Expression<Func<T, bool>> filter, string includeProperties = "")
        {
            await _repo.Delete(filter, includeProperties);
        }

        #endregion BaseRepository

        public IQueryable<T> GetWithPaging(Expression<Func<T, bool>> filter = null, string includeProperties = "", int take = default(int), int skip = default(int))
        {
            IQueryable<T> query = _repo.Get(filter, includeProperties);
            return query.Take(take).Skip(skip);
        }
    }
}
