using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DBContexts
{
    public class PaymentTypeMasterDBContext : ApplicationDBContext
    {
        public PaymentTypeMasterDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<PaymentTypeMaster> PaymentTypeMaster => Set<PaymentTypeMaster>();

    }
}
