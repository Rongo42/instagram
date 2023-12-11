using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Account : BaseEntity
    {
        public Account(string username, string password) 
        {
            Username = username;
            Password = password;
        }
        public string Username { get; set; }

        public string Password { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
