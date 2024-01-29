using DataAccessLibrary.Enum;
using DataAccessLibrary.IRepositories;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILogin _loginRepos;
        private readonly RoleManager<IdentityRole> _roleManager;

        public LoginService(ILogin loginRepos, RoleManager<IdentityRole> roleManager)
        {
            _loginRepos = loginRepos;
            _roleManager = roleManager;
        }

       
        public Task<UserData> Login(Login model)
        {
            return _loginRepos.Login(model);
        }

        
    }
}
