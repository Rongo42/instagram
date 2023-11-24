using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.Business.Encription;
using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ServiceLayer.Business.Encription.BCryptEncryption;

namespace ServiceLayer.CustomServices
{
    //Implements the custom Account Service Interface in order to define the TryLogin method, which is not declared in the generic interface
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _AccountRepository;

        public AccountService (IAccountRepository accountRepository)
        {
            _AccountRepository = accountRepository;
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
                    //Password uses an Extension Method of the string type in order to encrypt the input password
                    entity.Password = entity.Password.Encrypt();
                    _AccountRepository.Insert(entity);
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
            //Retrieving the account name inputed to try and login
            verifiedAccount = _AccountRepository.GetByAccountName(entity.Username);

            //It logs in if the verification checks out, uses shortwire in case the obtained account equals null
            //Password uses an Extension Method of the string type in order to statically verify if both match
            return verifiedAccount != null && entity.Password.Verify(verifiedAccount.Password);

        }
    }
}
