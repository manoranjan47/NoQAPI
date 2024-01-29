using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using MyAPI.Middlewares.Authentication;
using System.Text;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IJWTProvider _jwtProvider;
        private readonly ILoginService _loginService;

        public LoginController(IJWTProvider jwtProvider,ILoginService loginService)
        {
            _jwtProvider = jwtProvider;
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] Login model)
        {

            UserData userData=await _loginService.Login(model);
            if(userData == null)
            {
                return BadRequest("Invalid Credentials");
            }
            string token= await  _jwtProvider.GenerateTokenAsync(userData);
            userData.token= token;
            return Ok(userData);
        }


    }
}
