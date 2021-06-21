using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetAllForDate(DateTime date);
        Task Cancel(Reservation reservation);
        Task CancelAllForDate(DateTime date);
    }
}
