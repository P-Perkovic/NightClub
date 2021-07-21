﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NightClub.Domain.Models;

namespace NightClub.Infrastructure.Mappings
{
    public class TableMapping : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.OrdinalNumber)
                .IsRequired();

            builder.Property(b => b.CategoryId)
               .IsRequired();

            builder.ToTable("Tables");
        }
    }
}
