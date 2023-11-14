using ServiceLayer.ICustomServices;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.IRepository;
using System.Linq.Expressions;

namespace ServiceLayer.CustomServices
{
    public class UserService : ICustomService <User>
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                var obj = _userRepository.GetAll();
                
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User Get(int id)
        {
            try
            {
                var obj = _userRepository.Get(id);

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(User user)
        {
            try
            {
                if (user != null)
                {
                    _userRepository.Insert(user);
                    _userRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(User user)
        {
            try
            {
                if (user != null)
                {
                    _userRepository.Update(user);
                    _userRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(User user)
        {
            try
            {
                if (user != null )
                {
                    _userRepository.Delete(user);
                    _userRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void Remove(User user)
        {
            try
            {
                if (user != null)
                {
                    _userRepository.Remove(user);
                    _userRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
