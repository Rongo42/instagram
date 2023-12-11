using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Like : BaseEntity
    {
        public int PostId { get; set; }

        public Post Post { get; set; } = null!;

        public User Liker { get; set; }
    }
}
