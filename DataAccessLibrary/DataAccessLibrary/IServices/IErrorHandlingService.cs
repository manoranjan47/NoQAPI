using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IServices
{
    public interface IErrorHandlingService
    {
        void LogError(ErrorHandling errorHandling);
    }
}
