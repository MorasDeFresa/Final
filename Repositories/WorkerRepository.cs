using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nightclub.Data;
using NightClub.Models;

namespace NightClub.Repositories
{
    public interface IWorkerRepository
    {
        Task<List<Worker>> GetWorkers();
        Task<Worker> GetWorker(int IdWorker);
        Task<Worker> CreateWorker(Worker newWorker);
        Task<Worker> UpdateWorker(Worker Worker);
        Task<bool> DeleteWorker(int IdWorker);
    }

    public class WorkerRepository : IWorkerRepository
    {
        private readonly DataContext _db;

        public WorkerRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Worker> CreateWorker(Worker newWorker)
        {
            await _db.Workers.AddAsync(newWorker);
            await _db.SaveChangesAsync();
            return newWorker;
        }

        public async Task<bool> DeleteWorker(int IdWorker)
        {
            var Worker = await GetWorker(IdWorker);
            _db.Workers.Remove(Worker);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Worker> GetWorker(int IdWorker)
        {
            return await _db.Workers.FirstOrDefaultAsync(u => u.IdWorker == IdWorker);
        }
        public async Task<List<Worker>> GetWorkers()
        {
            return await _db.Workers.ToListAsync();
        }

        public async Task<Worker> UpdateWorker(Worker Worker)
        {
            _db.Workers.Update(Worker);
            await _db.SaveChangesAsync();
            return Worker;
        }
    }
}