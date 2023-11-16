using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Follower
    {
        public int Id { get; set; }
        public User Data { get; set; }
    }
}
