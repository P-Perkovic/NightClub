using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NightClub.Infrastructure.Mappings
{
    class ReservationMapping : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.NumberOfGuests)
                .IsRequired();

            builder.Property(r => r.DateOfReservation)
                .IsRequired();

            builder.Property(r => r.IsActive)
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(r => r.IsCanceled)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(r => r.IsCanceledByAdmin)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(r => r.Note);

            builder.Property(r => r.Status);

            // 1 : N => Reservation : Tables
            builder.HasOne(r => r.Table)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TableId);

            builder.ToTable("Reservations");
        }
    }
}
