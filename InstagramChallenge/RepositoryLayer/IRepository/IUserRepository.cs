using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        public void Follow(User follower, User followed);

        public void Unfollow(User follower, User followed);
    }
}
