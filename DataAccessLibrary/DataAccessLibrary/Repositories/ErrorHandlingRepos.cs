using DataAccessLibrary.DBContexts;
using DataAccessLibrary.IRepositories;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repositories
{
    public class ErrorHandlingRepos : IErrorHandling
    {
        private readonly ErrorHandlingDBContext dbContext;
        public ErrorHandlingRepos(ErrorHandlingDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void LogError(ErrorHandling errorHandling)
        {
            dbContext.ErrorHandlings.Add(errorHandling);
            dbContext.SaveChanges();
        }
    }
}
