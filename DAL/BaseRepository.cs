﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region Init

        protected DbContext _dbContext;
        protected DbSet<T> _dbSet;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        #endregion Init

        #region Implementation

        public virtual async Task Insert(T entity)
        {
            try
            {
                _dbContext.Add(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                //_logger.LogError(null, ex, "INSERT ERROR");
            }            
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            
            return query;
        }

        public virtual T GetByID(object id)
        {
            try
            {
                return _dbSet.Find(id); ;
            }
            catch (Exception ex)
            {
               // _logger.LogError(null, ex, "GetByID ERROR");
                return null;
            }            
        }

        public virtual IQueryable<T> GetAll(string includeProperties = "")
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query;
        }

        public virtual async Task Update(T entity)
        {
            try
            {
                _dbContext.Update(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;   // for confirm state of entity is Modified -> _dbSet update state entity.

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //_logger.LogError(null, ex, "Update ERROR");
            }
            
        }

        public virtual async Task Update(object primaryKey, T entity)
        {
            T dbEntity = this.GetByID(primaryKey);
            await this.Update(dbEntity);
        }

        public virtual async Task Delete(object primaryKey)
        {
            T dbEntity = this.GetByID(primaryKey);
            await this.Delete(dbEntity);
        }

        public virtual async Task Delete(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached) // check while processing server if entity modified -> attach entity into _dbSet again.
            {
                _dbSet.Attach(entity);
            }
            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Delete(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IList<T> query = this.Get(filter, includeProperties).ToList();
            foreach (var e in query)
            {
                await this.Delete(e);
            }
        }

        #endregion Implementation
    }
}