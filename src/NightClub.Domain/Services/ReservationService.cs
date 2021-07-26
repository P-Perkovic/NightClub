using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NightClub.Domain.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Reservation>> GetAllForCurrentUser(string userId)
        {
            return await _reservationRepository.GetAllForCurrentUser(userId);
        }

        public async Task<Reservation> Add(Reservation reservation)
        {
            await _reservationRepository.Add(reservation);

            return reservation;
        }

        public async Task<int> Cancel(int reservationId)
        {
            var reservation = await _reservationRepository.GetById(reservationId);

            if (reservation == null)
                return 0;

            await _reservationRepository.Cancel(reservation);
            return reservationId;
        }

        public async Task<bool> CancelForDate(DateTime date)
        {
            await _reservationRepository.CancelAllForDate(date);

            return true;
        }

        public async Task<IEnumerable<Reservation>> GetAllForDate(DateTime date)
        {
            return await _reservationRepository.GetAllForDate(date);
        }

        public async Task<IEnumerable<DateTime>> GetReservedDatesForUser(string userId)
        {
            return await _reservationRepository.GetReservedDatesForUser(userId);
        }

        public void Dispose()
        {
            _reservationRepository?.Dispose();
        }
    }
}
