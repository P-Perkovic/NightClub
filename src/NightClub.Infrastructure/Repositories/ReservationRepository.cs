using Microsoft.EntityFrameworkCore;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using NightClub.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Infrastructure.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(NightClubDbContext context) : base(context) { }

        public async Task<IEnumerable<Reservation>> GetAllForDate(DateTime date)
        {
            var reservations = await Db.Reservations.AsNoTracking().Where(r => r.IsActive == true && r.DateOfReservation == date)
                .Include(r => r.Table).ThenInclude(t => t.Category).Include(r => r.User).ToListAsync();

            foreach (var reservation in reservations)
            {
                reservation.SetReservationStatus();
                reservation.SetReservedFor();
            }

            return reservations;
        }

        public async Task Cancel(Reservation reservation)
        {
            reservation.IsCanceled = true;

            reservation.SetReservationStatus();

            Db.Update(reservation);
            await SaveChangesAsync();
        }

        public async Task CancelAllForDate(DateTime date, string note)
        {
            var reservations = await Db.Reservations.AsNoTracking().Where(r => r.DateOfReservation == date).ToListAsync();

            foreach(var reservation in reservations)
            {
                reservation.Note = note;
                reservation.IsCanceledByAdmin = true;
                reservation.SetReservationStatus();
            }

            Db.UpdateRange(reservations);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllForCurrentUser(string userId)
        {
            return await Db.Reservations.AsNoTracking().Where(r => r.UserStringId == userId)
                .Include(r => r.Table).ThenInclude(t => t.Category).OrderByDescending(r => r.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<DateTime>> GetReservedDatesForUser(string userId)
        {
            return await Db.Reservations.AsNoTracking()
                .Where(r => r.UserStringId == userId && r.IsActive == true && r.DateOfReservation >= DateTime.Now.Date)
                .OrderBy(r => r.DateOfReservation).Select(r => r.DateOfReservation).ToListAsync();
        }

        public async Task<IEnumerable<DateTime>> GetAllReservedDates()
        {
            return await Db.Reservations.AsNoTracking()
                .Where(r => r.IsActive == true && r.DateOfReservation >= DateTime.Now.Date)
                .OrderBy(r => r.DateOfReservation).GroupBy(r => r.DateOfReservation).Select(r => r.Key).ToListAsync();
        }
    }
}
