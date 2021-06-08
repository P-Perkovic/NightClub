using Microsoft.AspNetCore.Http;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        new Task Add(Article article, string photoURL);
        new Task Remove(Article article);
    }
}
