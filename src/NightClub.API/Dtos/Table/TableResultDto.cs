using NightClub.API.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.API.Dtos.Table
{
    public class TableResultDto
    {
        public int OrdinalNumber { get; set; }

        public CategoryResultDto Category { get; set; }
    }
}
