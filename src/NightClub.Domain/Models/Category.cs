using System;
using System.Collections.Generic;
using System.Text;

namespace NightClub.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }

        /* EF */
        public IEnumerable<Table> Tables { get; set; }
    }
}
