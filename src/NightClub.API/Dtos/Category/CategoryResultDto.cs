using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.API.Dtos.Category
{
    public class CategoryResultDto
    {
        public string Name { get; set; }

        public decimal MinBillValue { get; set; }

        public int MaxNumberOfGuests { get; set; }

    }
}
