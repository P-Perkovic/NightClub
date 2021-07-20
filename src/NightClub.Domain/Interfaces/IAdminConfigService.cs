using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface IAdminConfigService : IDisposable
    {
        Task<IEnumerable<AdminConfig>> GetAll();
        Task<AdminConfig> GetByKey(string key);
        Task<AdminConfig> Update(AdminConfig adminConfig);
    }
}
