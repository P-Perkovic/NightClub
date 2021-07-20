using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Domain.Interfaces
{
    public interface IAdminConfigRepository : IRepository<AdminConfig>
    {
        Task<AdminConfig> GetByKey(string key);
        new Task Update(AdminConfig adminConfig);
    }
}
