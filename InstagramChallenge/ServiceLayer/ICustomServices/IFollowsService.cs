using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ICustomServices
{
    public interface IFollowsService : ICustomService<Follows>
    {
        public void FollowUnfollow(User follower, User followed);

        public IEnumerable<Follows> GetFollowersByUserId(int Id);
    }
}
