using System;
using System.Collections.Generic;
using System.Text;

namespace NightClub.Domain.Models
{
    public class Reservation : Entity
    {
        public int TableId { get; set; }

        public DateTime DateOfReservation { get; set; }

        public int NumberOfGuests { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsCanceled { get; set; }

        /* EF */
        public Table Table { get; set; }
    }
}
