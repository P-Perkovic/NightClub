using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface IReservationService : IDisposable
    {
        Task<IEnumerable<Reservation>> GetAllForDate(DateTime date);
        Task<Reservation> Cancel(Reservation reservation);
        Task<Reservation> CancelForDate(DateTime date);
    }
}
