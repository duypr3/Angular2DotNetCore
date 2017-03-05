using Entity.Default;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class DefaultDbContext : DbContext
    {
        /*public DefaultDbContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.AutoDetectChangesEnabled = false;
        }
        */
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
             : base(options){ }
     
        public DbSet<Student> Students { set; get; }
        public DbSet<Class> Classes { set; get; }
        public DbSet<Teacher> Teachers { set; get; }
        public DbSet<Login> Logins { set; get; }
        
    }
}