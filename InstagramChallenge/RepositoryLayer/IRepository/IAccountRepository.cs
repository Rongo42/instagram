using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IAccountRepository : IRepository<Account>
    {
        public Account GetByAccountName(string accountName);
    }
}
