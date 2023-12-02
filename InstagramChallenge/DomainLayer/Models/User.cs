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

        [Required]
        public List<User> Followers { get; set; }

        public Account Account { get; set; }
    }
}
