using System.Collections.Generic;

namespace NightClub.Domain.Models
{
    public class Table : Entity
    {
        public int OrdinalNumber { get; set; }

        public int CategoryId { get; set; }

        /* EF */
        public Category Category { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
