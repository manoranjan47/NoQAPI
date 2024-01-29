using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DBContexts
{
    public class ErrorHandlingDBContext : ApplicationDBContext
    {
        public ErrorHandlingDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<ErrorHandling> ErrorHandlings { get; set; }

    }
}
