using DomainLayer.Data;
using DomainLayer.Models;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public Like LikeUnlike(User user, Post post, bool like)
        {
            return null;
        }
    }
}
