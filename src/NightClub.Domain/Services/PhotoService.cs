using Microsoft.AspNetCore.Http;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Domain.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IArticleRepository _articleRepository;

        public PhotoService(IPhotoRepository photoRepository, IArticleRepository articleRepository)
        {
            _photoRepository = photoRepository;
            _articleRepository = articleRepository;
        }

        public async Task<Photo> GetById(int id)
        {
            return await _photoRepository.GetById(id);
        }

        public async Task<Photo> GetByArticleId(int id)
        {
            return await _photoRepository.GetByArticleId(id);
        }

        public async Task<Photo> Add(int articleId, IFormFile file)
        {
            var article = await _articleRepository.GetById(articleId);
            if (article == null) return null;

            var photo = await _photoRepository.GetByArticleId(articleId);
            if (photo != null) return null;

            await _photoRepository.Add(articleId, file);
            return await _photoRepository.GetByArticleId(articleId);
        }

        public async Task<bool> Remove(Photo photo)
        {
            await _photoRepository.Remove(photo);
            return true;
        }

        public void Dispose()
        {
            _photoRepository?.Dispose();
        }
    }
}
