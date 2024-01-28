using DataAccessLibrary.Repositories;
using DataAccessLibrary.IRepositories;
using DataAccessLibrary.IServices;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Services
{
    public class PaymentTypeMasterService : IPaymentTypeService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IPaymentTypeMasterRepos _paymentTypeRepos;

        public PaymentTypeMasterService(IPaymentTypeMasterRepos paymentTypeRepos, IMemoryCache memoryCache)
        {
            _paymentTypeRepos = paymentTypeRepos;
            _memoryCache = memoryCache;
        }

        public Task<List<PaymentTypeMaster>> GetAllAsync()
        {
            string key = "PaymentType";
            var result = _memoryCache.GetOrCreateAsync(
                key,
                entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                    return _paymentTypeRepos.GetAllAsync();
                });
            return result;
        }
    }
}
