using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightClub.Infrastructure.Mappings
{
    class AdminCustomConfigMapping : IEntityTypeConfiguration<AdminCustomConfig>
    {
        public void Configure(EntityTypeBuilder<AdminCustomConfig> builder)
        {
            builder.HasKey(ac => ac.Key);

            builder.Ignore(ac => ac.Id);

            builder.Property(ac => ac.Value)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(ac => ac.TypeName)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.ToTable("AdminConfigs");
        }
    }
}
