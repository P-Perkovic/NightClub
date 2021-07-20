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
    public class AdminConfigRepository : Repository<AdminConfig>, IAdminConfigRepository
    {
        public AdminConfigRepository(NightClubDbContext context) : base(context) { }

        public async Task<AdminConfig> GetByKey(string key)
        {
            return await Db.AdminConfigs.AsNoTracking().FirstOrDefaultAsync(ac => ac.Key == key);
        }

        public override async Task Update(AdminConfig adminConfig)
        {
            var affectedRows = await Db.Database.ExecuteSqlRawAsync("EXEC dbo.stpUpdateAdminConfig {0}, {1}, {2}",
                parameters: new[] { adminConfig.Key, adminConfig.Value, adminConfig.TypeName });

            if (affectedRows == 0) throw new Exception("Problem with dbo.stpUpdateAdminConfig procedure!");
        }
    }
}
