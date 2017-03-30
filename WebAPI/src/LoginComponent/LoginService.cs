using DAL;
using Entity;
using WebAPI.Base;
using WebAPI.Common;

namespace WebAPI.src.LoginComponent
{    
    public class LoginService : BaseService<Login>, ILoginService
    {
        private readonly IBaseRepository<Login> _repo;
        public LoginService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repo = unitOfWork.GetRepository<Login>();
        }
    }
}