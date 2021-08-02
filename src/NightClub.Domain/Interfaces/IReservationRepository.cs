using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetAllForCurrentUser(string userId);
        Task<IEnumerable<Reservation>> GetAllForDate(DateTime date);
        Task Cancel(Reservation reservation);
        Task CancelAllForDate(DateTime date, string note);
        Task<IEnumerable<DateTime>> GetReservedDatesForUser(string userId);
        Task<IEnumerable<DateTime>> GetAllReservedDates();
        Task UpdateRange(IEnumerable<Reservation> reservations);
    }
}
