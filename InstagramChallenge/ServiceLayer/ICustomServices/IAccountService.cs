using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ICustomServices
{
    public interface IAccountService : ICustomService<Account>
    {
        public bool TryLogin(Account account, out Account verifiedAccount);
    }
}
