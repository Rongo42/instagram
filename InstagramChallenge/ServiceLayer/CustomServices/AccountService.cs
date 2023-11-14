using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.CustomServices
{
    public class AccountService : ICustomService <Account>
    {
        private readonly IRepository<Account> _AccountRepository;

        public AccountService (IRepository<Account> accountRepository)
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
    }
}
