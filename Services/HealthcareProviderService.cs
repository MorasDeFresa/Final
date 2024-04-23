using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NightClub.Models;
using NightClub.Repositories;

namespace NightClub.Services
{
    public interface IHealthcareProviderService
    {
        Task<List<HealthcareProvider>> GetTypesMoneyes();
        Task<HealthcareProvider> GetTypesMoney(int TypesMoneyid);
        Task<HealthcareProvider> createTypesMoney(long PhoneEmergency, string? TypesMoneyName = null);
        Task<HealthcareProvider> updateTypesMoney(int TypesMoneyid, string? TypesMoneyName = null, long? PhoneEmergency = null);
        Task<bool> deleteTypesMoney(int TypesMoneyid);
    }

    public class HealthcareProviderService : IHealthcareProviderService
    {
        private readonly HealthcareProviderRepository _typeRepository;
        public HealthcareProviderService(HealthcareProviderRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<HealthcareProvider> createTypesMoney(long PhoneEmergency, string? TypesMoneyName = null)
        {
            return await _typeRepository.CreateTypeMoney(TypesMoneyName, PhoneEmergency);
        }

        public async Task<bool> deleteTypesMoney(int TypesMoneyid)
        {
            await _typeRepository.DeleteTypeMoney(TypesMoneyid);
            return true;
        }

        public async Task<HealthcareProvider> GetTypesMoney(int TypesMoneyid)
        {
            return await _typeRepository.GetTypeMoney(TypesMoneyid);
        }

        public async Task<List<HealthcareProvider>> GetTypesMoneyes()
        {
            return await _typeRepository.GetTypeMoneys();
        }

        public async Task<HealthcareProvider> updateTypesMoney(int TypesMoneyid, string? NameTypeMoney = null, long? PhoneEmergency = null)
        {
            HealthcareProvider clase = await GetTypesMoney(TypesMoneyid);
            if (TypesMoneyid <= 0)
            {
                throw new ArgumentException("Class ID debe ser numero positivo.");
            }
            if (clase == null)
            {
                return null;
            }
            if (NameTypeMoney != null)
            {
                clase.NameHealthcareProvider = NameTypeMoney;
                clase.PhoneEmergency = (long)PhoneEmergency;
            }
            return await _typeRepository.UpdateTypeMoney(clase);
        }
    }
}