using Entity.DataMining;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class DataMiningDbContext : DbContext
    {
        /*public DataMiningDbContext() : base("DataMiningConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        */
        public DataMiningDbContext(DbContextOptions<DataMiningDbContext> options)
             : base(options){ }

        public DbSet<AccountSync> AccountSyncs { set; get; }
        public DbSet<TeacherSync> TeacherSyncs { set; get; }
       
    }
}