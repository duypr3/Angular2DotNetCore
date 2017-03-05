using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDbContextFactory
    {
        DbContext GetDefaultDbContext();

        DbContext GetDataMiningDbContext();
    }
}