using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.src.LoginComponent
{
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public Login GetById(int id)
        {
            var result = _loginService.GetByID(id);
            return result;
        }
        [HttpPost]
        public Login CreateAccount(Login login)
        {
            _loginService.Insert(login);

            return login;
        }

        [HttpPost]
        public async Task<Login> CreateAccountWithParams([FromBody] Login login, int param1, string param2)
        {
            var test = param1.ToString();
            GetWithParams(test, param2);
            await _loginService.Insert(login);
            GetAll();
            return login;
        }
        [HttpGet]
        public IList<Login> GetWithParams(string username, string password)
        {
            return _loginService.GetAll().ToList();
        }
        [HttpGet]
        public IList<Login> GetAll()
        {
            return _loginService.GetAll().ToList();
        }
        [HttpGet]
        public IList<Login> GetByInfo(string username, string password)
        {
            return _loginService.Get(n => n.Username.ToLower().Equals(username.ToLower())).ToList();
        }
        [HttpPost]
        public string Delete(string username)
        {
            _loginService.Delete(n => n.Username.Contains(username));
            return username;
        }
        [HttpPost]
        public long DeleteV1(long id)
        {
            _loginService.Delete(id);
            return id;
        }
    }
}