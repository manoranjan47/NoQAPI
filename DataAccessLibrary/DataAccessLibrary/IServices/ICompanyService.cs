using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IServices
{
    public interface ICompanyService<T> : IService<T> where T : BaseEntity
    {
    }
}
