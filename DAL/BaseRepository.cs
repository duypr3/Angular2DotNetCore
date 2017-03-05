using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

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

        public virtual void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbSet.Add(entity);
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
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetAll(string includeProperties = "")
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

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;   // for confirm state of entity is Modified -> _dbSet update state entity.
        }

        public virtual void Update(object primaryKey, T entity)
        {
            T dbEntity = this.GetByID(primaryKey);
            this.Update(dbEntity);
        }

        public virtual void Delete(object primaryKey)
        {
            T entity = _dbSet.Find(primaryKey);
            Delete(entity);
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (_dbContext.Entry(entity).State == EntityState.Detached) // check while processing server if entity modified -> attach entity into _dbSet again.
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> filter)
        {
            var objects = _dbSet.Where<T>(filter).AsEnumerable();
            foreach (var e in objects)
            {
                this.Delete(e);
            }
        }

        #endregion Implementation
    }
}