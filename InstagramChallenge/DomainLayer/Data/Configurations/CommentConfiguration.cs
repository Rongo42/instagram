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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder.Property(c => c.Message)
                .IsRequired()
                .HasColumnType("varchar(100)");
        }
    }
}
