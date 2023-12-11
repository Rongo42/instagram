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
    //Implements the custom Account Service Interface in order to define the FollowUnfollow method, which is not declared in the generic interface
    public class FollowsService : IFollowsService
    {
        private readonly IFollowsRepository _repository;

        public FollowsService(IFollowsRepository repository)
        {
            _repository = repository;
        }

        public void Delete(Follows entity)
        {
            try
            {
                _repository.Delete(entity);
                _repository.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void FollowUnfollow(int follower, int followed)
        { 
            //Firstly we obtain the follow action via the two parties involved in it (follower, followed)
            var obj = _repository.GetFollowsByUsers(follower, followed);

            //If the returned follow action is not null, meaning the relation between those 2 parties exists,
            //the method should delete said relation
            if (obj != null)
            {
                Delete(obj);
            }
            //If it is null, meaning the relation doesn't exist, the method should insert it
            else
            {
                //Since the obj variable was found null, we have to instantiate a new Follows object
                //composed by the ids provided from the method's parameters
                Follows follows = new()
                {
                    OwnerId = followed,
                    FollowerId = follower
                };
                Insert(follows);
            }
        }

        public IEnumerable<Follows> GetFollowersByUserId(int id)
        {
            try
            {
                var obj = _repository.GetFollowersByUserId(id);

                return obj;
            }
            catch
            {
                throw;
            }
        }

        public Follows Get(int Id)
        {
            try
            {
                var obj = _repository.Get(Id);

                return obj;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Follows> GetAll()
        {
            try
            {
                var obj = _repository.GetAll();

                return obj;
            }
            catch
            {
                throw;
            }
        }

        public void Insert(Follows entity)
        {
            try
            {
                _repository.Insert(entity);
                _repository.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Update(Follows entity)
        {
            try
            {
                _repository.Update(entity);
                _repository.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
