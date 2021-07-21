using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface ITableService : IDisposable
    {
        Task<IEnumerable<Table>> GetAll();
    }
}
