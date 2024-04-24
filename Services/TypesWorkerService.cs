using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NightClub.Models;
using NightClub.Repositories;

namespace NightClub.Services
{
    public interface ITypesWorkerService
    {
        Task<List<TypesWorker>> GetTypesMoneyes();
        Task<TypesWorker> GetTypesMoney(int TypesMoneyid);
        Task<TypesWorker> createTypesMoney(string TypeMoneyName, int SalaryForHour, int IdTypeMoney);
        Task<TypesWorker> updateTypesMoney(int TypesMoneyid, string TypesMoneyName, int SalaryForHour);
        Task<bool> deleteTypesMoney(int TypesMoneyid);
    }

    public class TypesWorkerService : ITypesWorkerService
    {
        private readonly ITypesWorkerRepository _typeRepository;
        public TypesWorkerService(ITypesWorkerRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<TypesWorker> createTypesMoney(string TypeMoneyName, int SalaryForHour, int IdTypeMoney)
        {
            return await _typeRepository.CreateTypeMoney(TypeMoneyName, SalaryForHour, IdTypeMoney);
        }

        public async Task<bool> deleteTypesMoney(int TypesMoneyid)
        {
            await _typeRepository.DeleteTypeMoney(TypesMoneyid);
            return true;
        }

        public async Task<TypesWorker> GetTypesMoney(int TypesMoneyid)
        {
            return await _typeRepository.GetTypeMoney(TypesMoneyid);
        }

        public async Task<List<TypesWorker>> GetTypesMoneyes()
        {
            return await _typeRepository.GetTypeMoneys();
        }

        public async Task<TypesWorker> updateTypesMoney(int TypesMoneyid, string TypesMoneyName, int SalaryForHour)
        {
            TypesWorker clase = await GetTypesMoney(TypesMoneyid);
            if (TypesMoneyid <= 0)
            {
                throw new ArgumentException("Class ID debe ser numero positivo.");
            }
            if (clase == null)
            {
                return null;
            }
            if (TypesMoneyName != null) clase.NameTypeWorker = TypesMoneyName;
            if (SalaryForHour != null) clase.SalaryForHour = SalaryForHour;
            return await _typeRepository.UpdateTypeMoney(clase);
        }
    }
}