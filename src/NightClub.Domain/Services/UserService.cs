using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetById(string id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User> Add(User user)
        {
            if (_userRepository.SearchAsync(u => u.StringId == user.StringId).Result.Any())
                return user;

            await _userRepository.Add(user);
            return user;
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}
