using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Domain.Services
{
    class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Reservation> Cancel(Reservation reservation)
        {
            await _reservationRepository.Cancel(reservation);
            return reservation;
        }

        public async Task<Reservation> CancelForDate(DateTime date)
        {
            await _reservationRepository.CancelAllForDate(date);

        }

        public async Task<IEnumerable<Reservation>> GetAllForDate(DateTime date)
        {
            return await _reservationRepository.GetAllForDate(date);
        }

        public void Dispose()
        {
            _reservationRepository?.Dispose();
        }
    }
}
