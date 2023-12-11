using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Comment : BaseEntity
    {
        public string Message { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; } = null!;
    }
}
