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
    public class CommentService : ICustomService <Comment>
    {
        private readonly IRepository<Comment> _CommentRepository;

        public CommentService (IRepository<Comment> commentRepository)
        {
            _CommentRepository = commentRepository;
        }

        public void Delete(Comment entity)
        {
            try
            {
                if (entity != null)
                {
                    _CommentRepository.Delete(entity);
                    _CommentRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
                
        }

        public Comment Get(int Id)
        {
            try
            {
                var obj = _CommentRepository.Get(Id);

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Comment> GetAll()
        {
            try
            {
                var obj = _CommentRepository.GetAll();

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Insert(Comment entity)
        {
            try
            {
                if (entity != null)
                {
                    //If the Comment message length is longer than 100, it should be truncated.
                    entity.Message = entity.Message?.Length > 100 ? entity.Message[..100] : entity.Message;
                    _CommentRepository.Insert(entity);
                    _CommentRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Comment entity)
        {
            try
            {
                if (entity != null)
                {
                    _CommentRepository.Update(entity);
                    _CommentRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
