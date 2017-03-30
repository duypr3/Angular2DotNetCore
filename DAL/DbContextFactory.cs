using Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DbContextFactory : IDbContextFactory
    {
        protected DbContext _defaultDbContext;
        protected DbContext _dataMiningDbContext;
   
        public DbContextFactory(DefaultDbContext defaultDbContext, DataMiningDbContext dataMiningDbContext)
        {
            _defaultDbContext = defaultDbContext;
            _dataMiningDbContext = dataMiningDbContext;
        }

        public DbContext GetDefaultDbContext()
        {
            return _defaultDbContext;
        }

        public DbContext GetDataMiningDbContext()
        {
            return _dataMiningDbContext;
        }
    }
}