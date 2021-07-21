using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(string id);
        Task<User> Add(User user);
    }
}
