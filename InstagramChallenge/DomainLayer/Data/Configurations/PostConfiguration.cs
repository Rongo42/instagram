using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder
                .HasMany(c => c.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .IsRequired();

            builder
                .HasMany(c => c.Likes)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
