﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using NightClub.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NightClub.Infrastructure.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {

        public ArticleRepository(NightClubDbContext context) : base(context) { }

        public async Task Add(Article article, string photoURL)
        {
            string uploadsFolderPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).ToString(), "NightClub-WebApp\\src\\assets\\photos");

            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var ext = Regex.Match(photoURL, @"data:image/(?<type>.+?),(?<data>.+)").Groups["type"].Value.Split(';')[0];

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension("." + ext);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            var base64Data = Regex.Match(photoURL, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            var binData = Convert.FromBase64String(base64Data);
            System.IO.File.WriteAllBytes(filePath, binData);

            article.PhotoFilePath = Path.Combine("assets\\photos", fileName);

            Db.Add(article);

            await SaveChangesAsync();
        }

        public async Task Update(Article article, string photoURL)
        {
            if(photoURL != null)
            {
                string uploadsFolderPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).ToString(), "NightClub-WebApp\\src");
                var filePath = Path.Combine(uploadsFolderPath, article.PhotoFilePath);

                File.Delete(filePath);

                uploadsFolderPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).ToString(), "NightClub-WebApp\\src\\assets\\photos");

                if (!Directory.Exists(uploadsFolderPath))
                    Directory.CreateDirectory(uploadsFolderPath);

                var ext = Regex.Match(photoURL, @"data:image/(?<type>.+?),(?<data>.+)").Groups["type"].Value.Split(';')[0];

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension("." + ext);
                filePath = Path.Combine(uploadsFolderPath, fileName);

                var base64Data = Regex.Match(photoURL, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
                var binData = Convert.FromBase64String(base64Data);
                System.IO.File.WriteAllBytes(filePath, binData);

                article.PhotoFilePath = Path.Combine("assets\\photos", fileName);
            }

            Db.Update(article);
            await SaveChangesAsync();
        }

        public override async Task Remove(Article article)
        {
            string uploadsFolderPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).ToString(), "NightClub-WebApp\\src");
            var filePath = Path.Combine(uploadsFolderPath, article.PhotoFilePath);

            File.Delete(filePath);

            Db.Remove(article);
            await SaveChangesAsync();
        }
    }
}
