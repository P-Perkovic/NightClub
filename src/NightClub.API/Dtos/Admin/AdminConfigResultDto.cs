using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.API.Dtos.Admin
{
    public class AdminConfigResultDto
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public string TypeName { get; set; }
    }
}
