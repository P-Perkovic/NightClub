﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NightClub.Domain.Models;

namespace NightClub.Infrastructure.Mappings
{
    class AdminConfigMapping : IEntityTypeConfiguration<AdminConfig>
    {
        public void Configure(EntityTypeBuilder<AdminConfig> builder)
        {
            builder.HasKey(ac => ac.Key);

            builder.Ignore(ac => ac.Id);

            builder.ToView("vwAdminConfigs");
        }
    }
}
