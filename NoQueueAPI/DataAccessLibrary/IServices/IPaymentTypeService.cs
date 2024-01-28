using DataAccessLibrary.IRepositories;
using DataAccessLibrary.Models;


namespace DataAccessLibrary.IServices
{
    public interface IPaymentTypeService
    {
        Task<List<PaymentTypeMaster>> GetAllAsync();
    }
}
