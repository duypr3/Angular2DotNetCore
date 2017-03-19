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
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Login> Logins { get; set; }

    }
}