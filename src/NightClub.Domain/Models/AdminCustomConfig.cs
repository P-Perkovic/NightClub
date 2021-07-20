using System;
using System.Collections.Generic;
using System.Text;

namespace NightClub.Domain.Models
{
    public class AdminCustomConfig : Entity
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public string TypeName { get; set; }
    }
}
