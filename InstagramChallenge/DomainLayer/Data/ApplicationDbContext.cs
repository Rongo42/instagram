using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet <User> Users { get; set; }

        public DbSet <Post> Posts { get; set; }

        public DbSet <Account> Accounts { get; set; }

        public DbSet <Comment> Comments { get; set; }

        public DbSet <Like> Likes { get; set; }

        public DbSet <Follows> Followss { get; set; }


    }
}
