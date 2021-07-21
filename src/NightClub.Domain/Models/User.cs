using System.Collections.Generic;

namespace NightClub.Domain.Models
{
    public class User : Entity
    {
        public string StringId { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }

        /* EF */
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
