using NightClub.Domain.Models;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        new Task Add(Article article, string photoURL);
        new Task Update(Article article, string photoURL);
        new Task Remove(Article article);
    }
}
