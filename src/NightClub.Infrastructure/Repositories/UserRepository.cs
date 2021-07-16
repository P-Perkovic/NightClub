using Microsoft.EntityFrameworkCore;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using NightClub.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(NightClubDbContext context) : base(context) { }

        public async Task<User> GetById(string id)
        {
            return await Db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.StringId == id);
        }
    }
}
