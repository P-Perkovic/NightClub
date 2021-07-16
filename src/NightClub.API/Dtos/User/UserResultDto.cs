using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.API.Dtos.User
{
    public class UserResultDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }
    }
}
