using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nightclub.Data;
using NightClub.Models;

namespace NightClub.Repositories
{
    public interface ITypesWorkerRepository
    {
        Task<List<TypesWorker>> GetTypeMoneys();
        Task<TypesWorker> GetTypeMoney(int TypeMoneyId);
        Task<TypesWorker> CreateTypeMoney(string TypeMoneyName, int SalaryForHour, int IdTypeMoney);
        Task<TypesWorker> UpdateTypeMoney(TypesWorker typesMoney);
        Task<bool> DeleteTypeMoney(int TypeMoneyId);
    }

    public class TypesWorkerRepository : ITypesWorkerRepository
    {
        private readonly DataContext _db;
        private readonly ITypeMoneyRepository _typesWorkerRepository;

        public TypesWorkerRepository(DataContext db, ITypeMoneyRepository typesWorkerRepository)
        {
            _db = db;
            _typesWorkerRepository = typesWorkerRepository;
        }
        public async Task<TypesWorker> CreateTypeMoney(string TypeMoneyName, int SalaryForHour, int IdTypeMoney)
        {
            var typeMoney = await _typesWorkerRepository.GetTypeMoney(IdTypeMoney);
            var newTypeMoney = new TypesWorker()
            {
                NameTypeWorker = TypeMoneyName,
                SalaryForHour = SalaryForHour,
                idTypeMoney = IdTypeMoney
            };

            await _db.TypesWorkers.AddAsync(newTypeMoney);
            _db.SaveChanges();
            return newTypeMoney;
        }
        public async Task<List<TypesWorker>> GetTypeMoneys()
        {
            return await _db.TypesWorkers.ToListAsync();
        }

        public async Task<TypesWorker> GetTypeMoney(int TypeMoneyId)
        {
            return await _db.TypesWorkers.FirstOrDefaultAsync(u => u.IdTypesWorker == TypeMoneyId);
        }

        public async Task<TypesWorker> UpdateTypeMoney(TypesWorker typesMoney)
        {
            _db.TypesWorkers.Update(typesMoney);
            await _db.SaveChangesAsync();
            return typesMoney;
        }

        public async Task<bool> DeleteTypeMoney(int TypeMoneyId)
        {
            var type = await GetTypeMoney(TypeMoneyId);
            _db.TypesWorkers.Remove(type);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}