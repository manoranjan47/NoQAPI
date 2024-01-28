using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.IRepositories
{
    public interface ICompanyRepos<T>:IRepository<T> where T : BaseEntity
    {

    }
}
