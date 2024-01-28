using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IServices
{
    public interface ILoginService 
    {
        Task<UserData> Login(Login model);
    }
}
