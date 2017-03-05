using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IUnitOfWork
    {
        DbContext GetDbContext();

        IBaseRepository<T> GetRepository<T>();
    }
}