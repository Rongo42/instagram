using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ICustomServices
{
    public interface ILikeService : ICustomService<Like>
    {
        public void LikeUnlike(Like entity);
    }
}
