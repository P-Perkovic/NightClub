using static NightClub.Domain.Constants;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using NightClub.Infrastructure.Context;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NightClub.Infrastructure.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {

        public ArticleRepository(NightClubDbContext context) : base(context) { }

        public async Task Add(Article article, string photoURL)
        {
            article.PhotoFilePath = AddFile(photoURL);

            Db.Add(article);

            await SaveChangesAsync();
        }

        public async Task Update(Article article, string photoURL)
        {
            if(photoURL != null)
            {
                DeleteFile(article.PhotoFilePath);

                article.PhotoFilePath = AddFile(photoURL);
            }

            Db.Update(article);
            await SaveChangesAsync();
        }

        public override async Task Remove(Article article)
        {
            DeleteFile(article.PhotoFilePath);

            Db.Remove(article);
            await SaveChangesAsync();
        }

        private string AddFile(string photoURL)
        {
            string uploadsFolderPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).ToString(), UPLOAD_FILE_PATH);

            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var ext = Regex.Match(photoURL, @"data:image/(?<type>.+?),(?<data>.+)").Groups["type"].Value.Split(';')[0];

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension("." + ext);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            var base64Data = Regex.Match(photoURL, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            var binData = Convert.FromBase64String(base64Data);
            System.IO.File.WriteAllBytes(filePath, binData);

            return Path.Combine(FILE_PATH, fileName);
        }

        private void DeleteFile(string filePath)
        {
            string uploadsFolderPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).ToString(), DELETE_FILE_PATH);
            filePath = Path.Combine(uploadsFolderPath, filePath);

            File.Delete(filePath);
        }
    }
}
