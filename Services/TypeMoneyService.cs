using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NightClub.Models;
using NightClub.Repositories;

namespace NightClub.Services
{
    public interface ITypesMoneyService
    {
        Task<List<TypeMoney>> GetTypesMoneyes();
        Task<TypeMoney> GetTypesMoney(int TypesMoneyid);
        Task<TypeMoney> createTypesMoney(string? TypesMoneyName = null);
        Task<TypeMoney> updateTypesMoney(int TypesMoneyid, string? TypesMoneyName = null);
        Task<bool> deleteTypesMoney(int TypesMoneyid);
    }

    public class TypesMoneyService : ITypesMoneyService
    {
        private readonly ITypeMoneyRepository _typeRepository;
        public TypesMoneyService(ITypeMoneyRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<TypeMoney> createTypesMoney(string? TypesMoneyName = null)
        {
            return await _typeRepository.CreateTypeMoney(TypesMoneyName);
        }

        public async Task<bool> deleteTypesMoney(int TypesMoneyid)
        {
            await _typeRepository.DeleteTypeMoney(TypesMoneyid);
            return true;
        }

        public async Task<TypeMoney> GetTypesMoney(int TypesMoneyid)
        {
            return await _typeRepository.GetTypeMoney(TypesMoneyid);
        }

        public async Task<List<TypeMoney>> GetTypesMoneyes()
        {
            return await _typeRepository.GetTypeMoneys();
        }

        public async Task<TypeMoney> updateTypesMoney(int TypesMoneyid, string? NameTypeMoney = null)
        {
            TypeMoney clase = await GetTypesMoney(TypesMoneyid);
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
                clase.NameTypeMoney = NameTypeMoney;
            }
            return await _typeRepository.UpdateTypeMoney(clase);
        }
    }
}