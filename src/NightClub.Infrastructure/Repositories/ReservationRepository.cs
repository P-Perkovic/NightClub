using Microsoft.EntityFrameworkCore;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using NightClub.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Infrastructure.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(NightClubDbContext context) : base(context) { }

        public async Task<IEnumerable<Reservation>> GetAllForDate(DateTime date)
        {
            return await Db.Reservations.AsNoTracking().Where(r => r.DateOfReservation == date).ToListAsync();
        }

        public async Task Cancel(Reservation reservation)
        {
            reservation.IsCanceled = true;
            reservation.IsActive = false;

            Db.Update(reservation);
            await SaveChangesAsync();
        }

        public async Task CancelAllForDate(DateTime date)
        {
            var reservations = await Db.Reservations.AsNoTracking().Where(r => r.DateOfReservation == date).ToListAsync();

            foreach(var reservation in reservations)
            {
                reservation.IsCanceled = true;
                reservation.IsActive = false;
            }

            Db.UpdateRange(reservations);
            await SaveChangesAsync();
        }
    }
}
