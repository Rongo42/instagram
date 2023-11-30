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
    //Implements the generic Custom Service in order to do CRUD operations
    public class LikeService : ICustomService<Like>
    {
        private readonly IRepository<Like> _LikeRepository;

        public LikeService(IRepository<Like> likeRepository)
        {
            _LikeRepository = likeRepository;
        }

        public void Delete(Like entity)
        {
            try
            {
                if (entity != null) 
                {
                    _LikeRepository.Delete(entity);
                    _LikeRepository.SaveChanges();
                }
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public Like Get(int Id)
        {
            try
            {
                var obj = _LikeRepository.Get(Id);

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Like> GetAll()
        {
            try
            {
                var obj = _LikeRepository.GetAll();

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(Like entity)
        {
            try
            {
                if (entity != null)
                {
                    _LikeRepository.Insert(entity);
                    _LikeRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Like entity)
        {
            try
            {
                if (entity != null)
                {
                    _LikeRepository.Update(entity);
                    _LikeRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void LikeUnlike(Like entity)
        {
            //We obtain the Like entity based on the one received as parameter
            var obj = Get(entity.Id);

            //If the entity exists then it should be removed
            if (obj != null)
            {
                Delete(obj);
            }
            //If it does not exist then it should be created using the inputed parameter
            else
            {
                Insert(entity);
            }
        }
    }
}
