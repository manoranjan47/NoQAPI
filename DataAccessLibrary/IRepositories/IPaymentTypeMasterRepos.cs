using DataAccessLibrary.Models;


namespace DataAccessLibrary.IRepositories
{
    public interface IPaymentTypeMasterRepos
    {
        Task<List<PaymentTypeMaster>> GetAllAsync();
    }
}
