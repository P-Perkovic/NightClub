using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using NightClub.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Infrastructure.Repositories
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(NightClubDbContext context) : base(context) { }

        public async Task<Photo> GetByArticleId(int id)
        {
            return await Db.Photos.AsNoTracking().Where(p => p.ArticleId == id)
                .FirstOrDefaultAsync();
        }

        public async Task Add(int articleId, IFormFile file)
        {
            string uploadsFolderPath = Path.Combine(Environment.CurrentDirectory, "uploads");

            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var photo = new Photo
            {
                FilePath = filePath,
                ArticleId = articleId
            };

            Db.Add(photo);
            await SaveChangesAsync();
        }

        public override async Task Remove(Photo photo)
        {
            File.Delete(photo.FilePath);

            Db.Remove(photo);
            await SaveChangesAsync();
        }
    }
}
