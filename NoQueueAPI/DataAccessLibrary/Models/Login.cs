using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserData : IdentityUser
    {
        public string Name { get; set; } = "";
        public string Mobile { get; set; } = "";
        public string Roles { get; set; } = "";
        public string token { get; set; }
    }


}
