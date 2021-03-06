﻿using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.src.LoginComponent
{
    [Route("api/[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ILogger _logger;

        // When using ILogger always add Controller into its.
        public LoginController(ILoginService loginService, ILogger<LoginController> logger)
        {
            _loginService = loginService;
            _logger = logger;
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
            //var test = param1.ToString();
            //GetWithParams(test, param2);
             await _loginService.Insert(login);
            return login;
        }

        [HttpGet]
        public IQueryable<Login> GetWithParams(string username, string password)
        {
            return _loginService.GetAll();
        }

        [HttpGet]
        public IQueryable<Login> GetAll()
        {
            return _loginService.GetAll().Take(20).Skip(2);
        }

        [HttpGet]
        public IQueryable<Login> GetByInfo(string username, string password)
        {
            return _loginService.Get(n => n.Username.ToLower().Contains(username.ToLower()));
        }

        [HttpPost]
        public async Task<string> Delete(string username)
        {
            await _loginService.Delete(n => n.Username.Equals(username));
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