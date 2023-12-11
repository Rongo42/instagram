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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.NickName)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder
                .HasMany(c => c.Followers)
                .WithOne(c => c.Owner)
                .HasForeignKey(c => c.OwnerId)
                .IsRequired();

            builder
                .HasOne(c => c.Account)
                .WithOne(c => c.User)
                .HasForeignKey<Account>(c => c.UserId)
                .IsRequired();

            builder
                .HasMany(c => c.Posts)
                .WithOne(c => c.Owner)
                .HasForeignKey(c => c.OwnerId)
                .IsRequired();
        }
    }
}
