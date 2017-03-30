using DAL;
using Entity;

namespace WebAPI.src.LoginComponent
{
    public interface ILoginRepository : IBaseRepository<Login>
    {
    }

    public class LoginRepository : BaseRepository<Login>, ILoginRepository
    {
        public LoginRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory.GetDefaultDbContext())
        {
        }
    }
}