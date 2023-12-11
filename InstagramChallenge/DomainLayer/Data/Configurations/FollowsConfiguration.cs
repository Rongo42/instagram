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
    public class FollowsConfiguration : IEntityTypeConfiguration<Follows>
    {
        public void Configure(EntityTypeBuilder<Follows> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.OwnerId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.FollowerId)
                .IsRequired()
                .HasColumnType("int");

        }
    }
}
