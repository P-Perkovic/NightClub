using NightClub.Domain.Models;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetById(string id);
    }
}
