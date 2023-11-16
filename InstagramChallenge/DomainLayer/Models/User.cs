using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class User : BaseEntity
    {
        public string NickName { get; set; }

        public List<Follower> Followers { get; set; }

        public Account Account { get; set; }
    }
}
