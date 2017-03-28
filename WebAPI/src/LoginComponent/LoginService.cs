using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Base;

namespace WebAPI.src.LoginComponent
{
    public class LoginService : BaseService<Login>, ILoginService
    {
        private readonly IBaseRepository<Login> _repo;
        public LoginService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _repo = UnitOfWork.GetRepository<Login>();
        }
    }
}
