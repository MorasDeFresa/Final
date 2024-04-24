using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nightclub.Data;
using NightClub.Models;

namespace NightClub.Repositories
{
    public interface IStatusWorkerRepository
    {
        Task<List<StatusWorker>> GetTypeMoneys();
        Task<StatusWorker> GetTypeMoney(int TypeMoneyId);
        Task<StatusWorker> CreateTypeMoney(string TypeMoneyName);
        Task<StatusWorker> UpdateTypeMoney(StatusWorker typesMoney);
        Task<bool> DeleteTypeMoney(int TypeMoneyId);
    }

    public class StatusWorkerRepository : IStatusWorkerRepository
    {
        private readonly DataContext _db;

        public StatusWorkerRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<StatusWorker> CreateTypeMoney(string TypeMoneyName)
        {
            var newTypeMoney = new StatusWorker()
            {
                NameStatus = TypeMoneyName,
            };

            await _db.StatusWorkers.AddAsync(newTypeMoney);
            _db.SaveChanges();
            return newTypeMoney;
        }
        public async Task<List<StatusWorker>> GetTypeMoneys()
        {
            return await _db.StatusWorkers.ToListAsync();
        }

        public async Task<StatusWorker> GetTypeMoney(int TypeMoneyId)
        {
            return await _db.StatusWorkers.FirstOrDefaultAsync(u => u.IdStatusWorker == TypeMoneyId);
        }

        public async Task<StatusWorker> UpdateTypeMoney(StatusWorker typesMoney)
        {
            _db.StatusWorkers.Update(typesMoney);
            await _db.SaveChangesAsync();
            return typesMoney;
        }

        public async Task<bool> DeleteTypeMoney(int TypeMoneyId)
        {
            var type = await GetTypeMoney(TypeMoneyId);
            _db.StatusWorkers.Remove(type);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}