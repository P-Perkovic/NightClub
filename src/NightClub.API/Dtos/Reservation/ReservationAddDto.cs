using System;
using System.ComponentModel.DataAnnotations;

namespace NightClub.API.Dtos.Reservation
{
    public class ReservationAddDto
    {
        [Required]
        public int TableId { get; set; }

        [Required]
        public string UserStringId { get; set; }

        [Required]
        public DateTime DateOfReservation { get; set; }

        [Required]
        public int NumberOfGuests { get; set; }

        public string ReservedFor { get; set; }

        public string Note { get; set; }
    }
}
