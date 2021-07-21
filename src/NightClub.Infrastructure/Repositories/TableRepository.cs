using Microsoft.EntityFrameworkCore;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using NightClub.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Infrastructure.Repositories
{
    public class TableRepository : Repository<Table>, ITableRepository
    {
        public TableRepository(NightClubDbContext context) : base(context) { }

        public override async Task<List<Table>> GetAll()
        {
            return await Db.Tables.AsNoTracking().Include(t => t.Category)
                .OrderBy(t => t.OrdinalNumber)
                .ToListAsync();
        }
    }
}
