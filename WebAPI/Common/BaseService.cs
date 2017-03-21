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
        private readonly IUnitOfWork _unitOfWork;
        private bool _autoSaveChange = true;
        protected DbContext _dbContext;

        public BaseService(IUnitOfWork unitOfWork, bool? autoSaveChange = true)
        {
            _unitOfWork = unitOfWork;
            _repo = unitOfWork.GetRepository<T>();
            _dbContext = unitOfWork.GetDbContext();
            if (autoSaveChange.HasValue)
            {
                _autoSaveChange = autoSaveChange.Value;
            }
        }

        /// <summary>
        /// For get Repository
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        #endregion init

        #region BaseRepository

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            return _repo.Get(filter, includeProperties);
        }

        public IQueryable<T> GetAll(string s)
        {
            return _repo.GetAll(s);
        }

        public T GetByID(object ID)
        {
            return _repo.GetByID(ID);
        }

        public void Insert(T o)
        {
            _repo.Insert(o);
            if (_autoSaveChange)
            {
                _dbContext.SaveChanges();
            }
        }

        public void Update(T o)
        {
            _repo.Update(o);
            if (_autoSaveChange)
            {
                _dbContext.SaveChanges();
            }
        }

        public void Update(object primaryKey, T o)
        {
            _repo.Update(primaryKey, o);
            if (_autoSaveChange)
            {
                _dbContext.SaveChanges();
            }
        }

        public void Delete(object primaryKey)
        {
            _repo.Delete(primaryKey);
            if (_autoSaveChange)
            {
                _dbContext.SaveChanges();
            }
        }

        public void Delete(T o)
        {
            _repo.Delete(o);
            if (_autoSaveChange)
            {
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Expression<Func<T, bool>> filter)
        {
            _repo.Delete(filter);
            if (_autoSaveChange)
            {
                _dbContext.SaveChanges();
            }
        }

        #endregion BaseRepository

        public IQueryable<T> GetWithPaging(Expression<Func<T, bool>> filter = null, string includeProperties = "", int take = default(int), int skip = default(int))
        {
            IQueryable<T> query = _repo.Get(filter, includeProperties);
            return query.Take(take).Skip(skip);
        }
    }
}
