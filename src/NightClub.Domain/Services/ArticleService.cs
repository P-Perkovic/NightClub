using Microsoft.AspNetCore.Http;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Domain.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Article> Add(Article article, string photoURL)
        {
            if (_articleRepository.SearchAsync(a => a.Title == article.Title).Result.Any())
                return null;

            await _articleRepository.Add(article, photoURL);
            return article;
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            return await _articleRepository.GetAll();
        }

        public async Task<Article> GetById(int id)
        {
            return await _articleRepository.GetById(id);
        }

        public async Task<bool> Remove(Article article)
        {
            await _articleRepository.Remove(article);
            return true;
        }

        public async Task<Article> Update(Article article)
        {
            if (_articleRepository.SearchAsync(a => a.Title == article.Title && a.Id != article.Id).Result.Any())
                return null;

            await _articleRepository.Update(article);
            return article;
        }

        public void Dispose()
        {
            _articleRepository?.Dispose();
        }
    }
}
