using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IFollowsRepository : IRepository<Follows>
    {
        public Follows GetFollowsByUsers(int followedUser, int followerUser);

        public IEnumerable<Follows> GetFollowersByUserId(int Id);
    }
}
