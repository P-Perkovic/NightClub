using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightClub.Infrastructure.Mappings
{
    class PhotoMapping : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FilePath)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.HasOne(p => p.Article)
                .WithOne(a => a.Photo)
                .HasForeignKey<Photo>(p => p.ArticleId);
        }
    }
}
