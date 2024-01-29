using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccessLibrary.DBContexts
{
    public class CompanyDBContext : ApplicationDBContext
    {
        public CompanyDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<CompanyMaster> Companies => Set<CompanyMaster>();
        public DbSet<Branch> Branches => Set<Branch>();
    }
}
