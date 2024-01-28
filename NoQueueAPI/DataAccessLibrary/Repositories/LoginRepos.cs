using DataAccessLibrary.IRepositories;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repositories
{
    public class LoginRepos : ILogin
    {
        

        public Task<UserData> Login(Login model)
        {
            UserData userData = new UserData()
            {
                Name = "Manoranjan",
                Email = "manoranjan47@gmail.com",
                Mobile = "9650915400",
                Roles = "User",
                UserName = model.UserName
            };

            return Task.FromResult(userData);
        }

    }
}
