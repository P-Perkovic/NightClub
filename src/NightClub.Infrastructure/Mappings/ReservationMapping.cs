using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NightClub.Domain.Models;
using static NightClub.Domain.Constants;

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

            builder.Property(r => r.ReservedFor)
                .HasColumnType("varchar(255)");

            builder.Property(r => r.Note);

            builder.Property(r => r.Status)
                .HasDefaultValue((int)ReservationStatus.Active); 

            // 1 : N => Table : Reservations
            builder.HasOne(r => r.Table)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TableId);

            // 1 : N => User : Reservations
            builder.HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserStringId);

            builder.ToTable("Reservations");
        }
    }
}
