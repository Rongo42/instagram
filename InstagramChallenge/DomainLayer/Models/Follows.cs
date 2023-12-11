using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Follows : BaseEntity
    {
        public int OwnerId { get; set; }

        public User Owner { get; set; } = null!;

        public int FollowerId { get; set; }
    }
}
