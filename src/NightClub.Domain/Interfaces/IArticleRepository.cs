using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        new Task<List<Article>> GetAll();
        new Task<Article> GetById(int id);
    }
}
