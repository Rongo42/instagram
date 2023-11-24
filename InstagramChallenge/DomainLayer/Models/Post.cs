using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Post : BaseEntity
    {
        public User? Owner { get; set; }

        public string Description { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Like> Likes { get; set; }
    }

}
