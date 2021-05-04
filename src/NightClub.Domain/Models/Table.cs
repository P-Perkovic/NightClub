using System;
using System.Collections.Generic;
using System.Text;

namespace NightClub.Domain.Models
{
    public class Table : Entity
    {
        public int OrdinalNumber { get; set; }

        public int MaxNumberOfGuests { get; set; }

        public int CategoryId { get; set; }

        /* EF */
        public Category Category { get; set; }
    }
}
