using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NightClub.Domain.Models;

namespace NightClub.Infrastructure.Mappings
{
    class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Title)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(a => a.Content)
                .IsRequired();

            builder.Property(a => a.PublishingDate)
               .IsRequired();

            builder.ToTable("Articles");
        }
    }
}
