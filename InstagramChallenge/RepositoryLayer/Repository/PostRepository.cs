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

        public bool LikeUnlike(User user, Post post, bool like)
        {
            if (post != null)
            {
                var _found = post.Likes.Find(c => c.Id == user.Id);

                if (_found != null)
                {
                    if (like) { return false; }
                    else { return true; }
                }
                else
                {
                    if (like) { return true; }
                    else { return false; }
                }
            }
            else
            {
                return false;
            }
        }
    }
}
