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
    public class PostService : ICustomService<Post>
    {
        private readonly IRepository<Post> _PostRepository;

        public PostService(IRepository<Post> postRepository) 
        {
            _PostRepository = postRepository;
        }

        public void Delete(Post entity)
        {
            try
            {
                if (entity != null)
                {
                    _PostRepository.Delete(entity);
                    _PostRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Post Get(int Id)
        {
            try
            {
                var obj = _PostRepository.Get(Id);

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Post> GetAll()
        {
            try
            {
                var obj = _PostRepository.GetAll();

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(Post entity)
        {
            try
            {
                if (entity != null)
                {
                    _PostRepository.Insert(entity);
                    _PostRepository.SaveChanges();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(Post entity)
        {
            try
            {
                if (entity != null)
                {
                    _PostRepository.Remove(entity);
                    _PostRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Post entity)
        {
            try
            {
                if (entity != null)
                {
                    _PostRepository.Update(entity);
                    _PostRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
