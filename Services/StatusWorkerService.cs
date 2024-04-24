using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NightClub.Models;
using NightClub.Repositories;

namespace NightClub.Services
{
    public interface IStatusWorkersService
    {
        Task<List<StatusWorker>> GetTypesMoneyes();
        Task<StatusWorker> GetTypesMoney(int TypesMoneyid);
        Task<StatusWorker> createTypesMoney(string? TypesMoneyName = null);
        Task<StatusWorker> updateTypesMoney(int TypesMoneyid, string? TypesMoneyName = null);
        Task<bool> deleteTypesMoney(int TypesMoneyid);
    }

    public class StatusWorkersService : IStatusWorkersService
    {
        private readonly IStatusWorkerRepository _typeRepository;
        public StatusWorkersService(IStatusWorkerRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<StatusWorker> createTypesMoney(string? TypesMoneyName = null)
        {
            return await _typeRepository.CreateTypeMoney(TypesMoneyName);
        }

        public async Task<bool> deleteTypesMoney(int TypesMoneyid)
        {
            await _typeRepository.DeleteTypeMoney(TypesMoneyid);
            return true;
        }

        public async Task<StatusWorker> GetTypesMoney(int TypesMoneyid)
        {
            return await _typeRepository.GetTypeMoney(TypesMoneyid);
        }

        public async Task<List<StatusWorker>> GetTypesMoneyes()
        {
            return await _typeRepository.GetTypeMoneys();
        }

        public async Task<StatusWorker> updateTypesMoney(int TypesMoneyid, string? NameTypeMoney = null)
        {
            StatusWorker clase = await GetTypesMoney(TypesMoneyid);
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
                clase.NameStatus = NameTypeMoney;
            }
            return await _typeRepository.UpdateTypeMoney(clase);
        }
    }
}