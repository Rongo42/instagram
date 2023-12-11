using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class User : BaseEntity
    {
        public string NickName { get; set; }

        public List<Follows> Followers { get; set; }

        public Account Account { get; set; }

        public List<Post> Posts { get; set; }

        public int LikeId { get; set; }

        public Like Like { get; set; } = null!;
    }
}
