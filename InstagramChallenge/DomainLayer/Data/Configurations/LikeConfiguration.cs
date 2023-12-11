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
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder
                .HasOne(c => c.Liker)
                .WithOne(c => c.Like)
                .HasForeignKey<User>(c => c.LikeId)
                .IsRequired();
        }
    }
}
