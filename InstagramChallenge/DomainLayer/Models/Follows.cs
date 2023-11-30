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

        public int FollowerId { get; set; }
    }
}
