using DomainLayer.Data;
using DomainLayer.Models;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public Account GetByAccountName(string accountName)
        {
            return entities.SingleOrDefault(c => c.Username == accountName);
        }
    }
}
