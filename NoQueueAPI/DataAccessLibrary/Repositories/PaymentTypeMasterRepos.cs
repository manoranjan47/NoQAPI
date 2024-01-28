using DataAccessLibrary.DBContexts;
using DataAccessLibrary.IRepositories;
using DataAccessLibrary.Models;


namespace DataAccessLibrary.Repositories
{
    public class PaymentTypeMasterRepos : IPaymentTypeMasterRepos
    {

        private readonly PaymentTypeMasterDBContext _dbContext;

        public PaymentTypeMasterRepos(PaymentTypeMasterDBContext dbContext)
        {

            _dbContext = dbContext;

        }

        public Task<List<PaymentTypeMaster>> GetAllAsync()
        {

            var result = _dbContext.PaymentTypeMaster.ToList();
            return Task.FromResult(result);
        }
    }
}
