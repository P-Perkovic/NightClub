using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        Task<IEnumerable<Category>> GetAll();

        Task<Category> Update(Category category);
    }
}
