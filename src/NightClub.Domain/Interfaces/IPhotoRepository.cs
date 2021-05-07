using Microsoft.AspNetCore.Http;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        Task<Photo> GetByArticleId(int id);
        Task Add(int articleId, IFormFile file);
        new Task Remove(Photo photo);
    }
}
