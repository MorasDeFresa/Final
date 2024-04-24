using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nightclub.Data;
using NightClub.Models;

namespace NightClub.Repositories
{
    public interface ISchedulesWorkerRepository
    {
        Task<List<SchedulesWorker>> GetClients();
        Task<SchedulesWorker> GetClient(int IdSchedulesWorker);
        Task<SchedulesWorker> CreateClient(SchedulesWorker newClient);
        Task<SchedulesWorker> UpdateClient(SchedulesWorker SchedulesWorker);
        Task<bool> DeleteClient(int IdSchedulesWorker);
    }

    public class SchedulesWorkerRepository : ISchedulesWorkerRepository
    {
        private readonly DataContext _db;

        public SchedulesWorkerRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<SchedulesWorker> CreateClient(SchedulesWorker newClient)
        {
            await _db.SchedulesWorkers.AddAsync(newClient);
            await _db.SaveChangesAsync();
            return newClient;
        }

        public async Task<bool> DeleteClient(int IdSchedulesWorker)
        {
            var client = await GetClient(IdSchedulesWorker);
            _db.SchedulesWorkers.Remove(client);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<SchedulesWorker> GetClient(int IdSchedulesWorker)
        {
            return await _db.SchedulesWorkers.FirstOrDefaultAsync(u => u.IdSchedule == IdSchedulesWorker);
        }
        public async Task<List<SchedulesWorker>> GetClients()
        {
            return await _db.SchedulesWorkers.ToListAsync();
        }

        public async Task<SchedulesWorker> UpdateClient(SchedulesWorker SchedulesWorker)
        {
            _db.SchedulesWorkers.Update(SchedulesWorker);
            await _db.SaveChangesAsync();
            return SchedulesWorker;
        }
    }
}