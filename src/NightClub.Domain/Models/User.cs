using System;
using System.Collections.Generic;
using System.Text;

namespace NightClub.Domain.Models
{
    public class User : Entity
    {
        public string StringId { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }
    }
}
