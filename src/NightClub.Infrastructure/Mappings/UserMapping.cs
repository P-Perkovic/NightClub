using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightClub.Infrastructure.Mappings
{
    class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.StringId);

            builder.Ignore(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(u => u.Nickname)
                .HasColumnType("varchar(255)");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.ToTable("Users");
        }
    }
}
