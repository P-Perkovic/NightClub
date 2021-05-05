using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.API.Dtos.Table
{
    public class TableResultDto
    {
        public int OrdinalNumber { get; set; }

        public int CategoryId { get; set; }

        public int MaxNumberOfGuests { get; set; }

        public string CategoryName { get; set; }
    }
}
