using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IPostRepository : IRepository<Post>
    {
        public Like LikeUnlike(User user, Post post, bool like);

    }
}
