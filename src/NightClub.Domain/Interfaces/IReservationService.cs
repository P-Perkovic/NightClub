using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface IReservationService : IDisposable
    {
        Task<IEnumerable<Reservation>> GetAllForDate(DateTime date);
        Task<IEnumerable<Reservation>> GetAllForCurrentUser(string userId);
        Task<Reservation> Add(Reservation reservation);
        Task<int> Cancel(int reservationId);
        Task<bool> CancelForDate(DateTime date);
        Task<IEnumerable<DateTime>> GetReservedDatesForUser(string userId);
    }
}
