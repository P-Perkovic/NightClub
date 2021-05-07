using Microsoft.EntityFrameworkCore;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using NightClub.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Infrastructure.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(NightClubDbContext context) : base(context) { }

        public override async Task<List<Article>> GetAll()
        {
            return await Db.Articles.AsNoTracking().Include(a => a.Photo)
                .OrderByDescending(a => a.PublishingDate)
                .ToListAsync();
        }

        public override async Task<Article> GetById(int id)
        {
            return await Db.Articles.AsNoTracking().Include(a => a.Photo)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
