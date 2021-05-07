using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightClub.Infrastructure.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.MinBillValue)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // 1 : N => Category : Tables
            builder.HasMany(c => c.Tables)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId);

            builder.ToTable("Categories");
        }
    }
}
