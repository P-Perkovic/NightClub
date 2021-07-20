using NightClub.Domain.Interfaces;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightClub.Domain.Services
{
    public class AdminConfigService : IAdminConfigService
    {
        private readonly IAdminConfigRepository _adminConfigRepository;

        public AdminConfigService(IAdminConfigRepository adminConfigRepository)
        {
            _adminConfigRepository = adminConfigRepository;
        }

        public async Task<IEnumerable<AdminConfig>> GetAll()
        {
            return await _adminConfigRepository.GetAll();
        }

        public async Task<AdminConfig> GetByKey(string key)
        {
            return await _adminConfigRepository.GetByKey(key);
        }

        public async Task<AdminConfig> Update(AdminConfig adminConfig)
        {
            if (_adminConfigRepository.SearchAsync(ac => ac.Key == adminConfig.Key).Result.Count() < 1)
                return null;

            await _adminConfigRepository.Update(adminConfig);
            return adminConfig;
        }

        public void Dispose()
        {
            _adminConfigRepository?.Dispose();
        }
    }
}
