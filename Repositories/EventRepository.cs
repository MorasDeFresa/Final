using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nightclub.Data;
using NightClub.Models;

namespace NightClub.Repositories
{
    public interface IEventRepository
    {
        Task<List<Event>> GetTypeMoneys();
        Task<Event> GetEvent(int IdEvent);
        Task<Event> CreateEvent(string NameEvent, DateOnly DateEvent, int MaximumClientCapacity);
        Task<Event> UpdateEvent(Event events);
        Task<bool> DeleteEvent(int IdEvent);
    }

    public class EventRepository : IEventRepository
    {
        private readonly DataContext _db;

        public EventRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<Event> CreateEvent(string NameEvent, DateOnly DateEvent, int MaximumClientCapacity)
        {
            var newTypeMoney = new Event()
            {
                NameEvent = NameEvent,
                DateEvent = DateEvent,
                MaximumClientCapacity = MaximumClientCapacity
            };

            await _db.Events.AddAsync(newTypeMoney);
            _db.SaveChanges();
            return newTypeMoney;
        }
        public async Task<List<Event>> GetTypeMoneys()
        {
            return await _db.Events.ToListAsync();
        }

        public async Task<Event> GetEvent(int IdEvent)
        {
            return await _db.Events.FirstOrDefaultAsync(u => u.IdEvent == IdEvent);
        }

        public async Task<Event> UpdateEvent(Event events)
        {
            _db.Events.Update(events);
            await _db.SaveChangesAsync();
            return events;
        }

        public async Task<bool> DeleteEvent(int IdEvent)
        {
            var type = await GetEvent(IdEvent);
            _db.Events.Remove(type);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}