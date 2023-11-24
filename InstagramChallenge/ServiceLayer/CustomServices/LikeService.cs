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

        //Delete handles the Unlike requirement
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

        //Insert handles the Like requirement
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
    }
}
