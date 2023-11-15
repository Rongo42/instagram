using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.Business.Encription;
using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.CustomServices
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _AccountRepository;

        private readonly IEncryption _encryption;

        public AccountService (IAccountRepository accountRepository, IEncryption encryption)
        {
            _AccountRepository = accountRepository;
            _encryption = encryption;
        }

        public void Delete(Account entity)
        {
            try
            {
                if (entity != null)
                {
                    _AccountRepository.Delete (entity);
                    _AccountRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Account Get(int Id)
        {
            try
            {
                var obj = _AccountRepository.Get(Id);

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Account> GetAll()
        {
            try
            {
                var obj = _AccountRepository.GetAll();
                
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(Account entity)
        {
            try
            {
                if (entity != null)
                {
                    _AccountRepository.Insert (entity);
                    _AccountRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(Account entity)
        {
            try
            {
                if (entity != null)
                {
                    _AccountRepository.Remove (entity);
                    _AccountRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Account entity)
        {
            try
            {
                if (entity != null)
                {
                    _AccountRepository.Update (entity);
                    _AccountRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool TryLogin(Account entity, out Account verifiedAccount)
        {
            verifiedAccount = _AccountRepository.GetByAccountName(entity.Username);

            return (verifiedAccount == null) ? false : _encryption.Verify(entity.Password, verifiedAccount.Password);

        }
    }
}
