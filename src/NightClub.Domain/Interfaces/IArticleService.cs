using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface IArticleService : IDisposable
    {
        Task<IEnumerable<Article>> GetAll();
        Task<Article> GetById(int id);
        Task<Article> Add(Article article);
        Task<Article> Update(Article article);
        Task<bool> Remove(Article article);
    }
}
