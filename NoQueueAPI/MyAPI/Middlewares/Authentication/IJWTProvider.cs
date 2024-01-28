using DataAccessLibrary.Models;

namespace MyAPI.Middlewares.Authentication
{
    public interface IJWTProvider
    {
        public Task<string> GenerateTokenAsync(UserData userData);
    }
}
