using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> Update(Category category)
        {
            await _categoryRepository.Update(category);
            return category;
        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }
    }
}
