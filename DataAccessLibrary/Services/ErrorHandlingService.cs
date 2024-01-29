using DataAccessLibrary.IRepositories;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Services
{
    public class ErrorHandlingService : IErrorHandlingService
    {
        private readonly IErrorHandling _errorHandling;

        public ErrorHandlingService(IErrorHandling errorHandling)
        {
            _errorHandling = errorHandling;
        }
        public void LogError(ErrorHandling errorHandling)
        {
            _errorHandling.LogError(errorHandling);
        }
    }
}
