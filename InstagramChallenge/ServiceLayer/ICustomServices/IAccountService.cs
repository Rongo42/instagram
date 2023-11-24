using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ICustomServices
{
    //Inherits from the Custom Service interface in order to have the basic CRUD operations and declares a new required method
    public interface IAccountService : ICustomService<Account>
    {
        public bool TryLogin(Account account, out Account verifiedAccount);
    }
}
