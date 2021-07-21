using NightClub.API.Dtos.Table;
using System;

namespace NightClub.API.Dtos.Reservation
{
    public class ReservationResultDto
    {
        public int Id { get; set; }

        public DateTime DateOfReservation { get; set; }

        public int NumberOfGuests { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsCanceled { get; set; }

        public bool? IsCanceledByAdmin { get; set; }

        public string ReservedFor { get; set; }

        public string Note { get; set; }

        public int Status { get; set; }

        public TableResultDto Table { get; set; }
    }
}
