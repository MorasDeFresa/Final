using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nightclub.Data;
using NightClub.Models;

namespace NightClub.Repositories
{
    public interface IHealthcareProviderRepository
    {
        Task<List<HealthcareProvider>> GetTypeMoneys();
        Task<HealthcareProvider> GetTypeMoney(int TypeMoneyId);
        Task<HealthcareProvider> CreateTypeMoney(string TypeMoneyName, long PhoneEmergency);
        Task<HealthcareProvider> UpdateTypeMoney(HealthcareProvider typesMoney);
        Task<bool> DeleteTypeMoney(int TypeMoneyId);
    }

    public class HealthcareProviderRepository : IHealthcareProviderRepository
    {
        private readonly DataContext _db;

        public HealthcareProviderRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<HealthcareProvider> CreateTypeMoney(string TypeMoneyName, long PhoneEmergency)
        {
            var newTypeMoney = new HealthcareProvider()
            {
                NameHealthcareProvider = TypeMoneyName,
                PhoneEmergency = PhoneEmergency
            };

            await _db.HealthcareProviders.AddAsync(newTypeMoney);
            _db.SaveChanges();
            return newTypeMoney;
        }
        public async Task<List<HealthcareProvider>> GetTypeMoneys()
        {
            return await _db.HealthcareProviders.ToListAsync();
        }

        public async Task<HealthcareProvider> GetTypeMoney(int TypeMoneyId)
        {
            return await _db.HealthcareProviders.FirstOrDefaultAsync(u => u.IdHealthcareProvider == TypeMoneyId);
        }

        public async Task<HealthcareProvider> UpdateTypeMoney(HealthcareProvider typesMoney)
        {
            _db.HealthcareProviders.Update(typesMoney);
            await _db.SaveChangesAsync();
            return typesMoney;
        }

        public async Task<bool> DeleteTypeMoney(int TypeMoneyId)
        {
            var type = await GetTypeMoney(TypeMoneyId);
            _db.HealthcareProviders.Remove(type);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}