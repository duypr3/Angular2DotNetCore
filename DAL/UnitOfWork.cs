using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Init

        private DbContext _dbContext;
        private readonly IDbContextFactory _contextFactory;

        public UnitOfWork(IDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _dbContext = contextFactory.GetDefaultDbContext();
        }

        #endregion Init

        #region Repositories

        private IBaseRepository<Student> _studentRepository;
        private IBaseRepository<Class> _classRepository;
        private IBaseRepository<Login> _loginRepository;

        private IBaseRepository<Student> StudentRepository
        {
            get { return _studentRepository ?? (_studentRepository = new BaseRepository<Student>(_dbContext)); }
        }

        private IBaseRepository<Class> ClassRepository
        {
            get { return _classRepository ?? (_classRepository = new BaseRepository<Class>(_dbContext)); }
        }

        private IBaseRepository<Login> LoginRepository
        {
            get { return _loginRepository ?? (_loginRepository = new BaseRepository<Login>(_dbContext)); }
        }

        public IBaseRepository<T> GetRepository<T>()
        {
            var type = typeof(T);
            if (type == typeof(Student)) return StudentRepository as IBaseRepository<T>;
            else if (type == typeof(Class)) return ClassRepository as IBaseRepository<T>;
            else if (type == typeof(Login)) return LoginRepository as IBaseRepository<T>;

            return null;
        }

        public DbContext GetDbContext()
        {
            return _dbContext;
        }

        #endregion Repositories

        //#region Dispose

        ///// <summary>
        ///// Disposes the current object
        ///// </summary>
        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        ///// <summary>
        ///// Disposes all external resources.
        ///// </summary>
        ///// <param name="disposing">The dispose indicator.</param>
        //private void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (_dbContext != null)
        //        {
        //            _dbContext.Dispose();
        //            _dbContext = null;
        //        }
        //    }
        //}

        //#endregion Dispose
    }
}