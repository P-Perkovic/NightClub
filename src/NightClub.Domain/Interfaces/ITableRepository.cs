using NightClub.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface ITableRepository : IRepository<Table>
    {
        new Task<List<Table>> GetAll();
    }
}
