using DAL;
using Entity;
using WebAPI.Base;

namespace WebAPI.src.LoginComponent
{
    public class LoginService : BaseService<Login>, ILoginService
    {
        private readonly IBaseRepository<Login> _repo;

        public LoginService(ILoginRepository loginRepo) : base(loginRepo)
        {
        }
    }
}