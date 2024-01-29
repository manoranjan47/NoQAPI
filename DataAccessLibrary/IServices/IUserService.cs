using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IServices
{
    public interface IUserService<T> : IService<T> where T : BaseEntity
    {
        Task<IEnumerable<UserMaster>> GetUserDataAsync(int? UserId = null, string? Mobile = null, int? BranchId = null);

    }
}
