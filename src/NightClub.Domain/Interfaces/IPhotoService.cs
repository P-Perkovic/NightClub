using Microsoft.AspNetCore.Http;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface IPhotoService :IDisposable
    {
        Task<Photo> GetById(int id);
        Task<Photo> GetByArticleId(int id);
        Task<Photo> Add(int articleId, IFormFile file);
        Task<bool> Remove(Photo photo);
    }
}
