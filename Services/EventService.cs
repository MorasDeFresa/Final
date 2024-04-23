using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NightClub.Models;
using NightClub.Repositories;

namespace NightClub.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetTypesMoneyes();
        Task<Event> GetTypesMoney(int TypesMoneyid);
        Task<Event> createTypesMoney(string TypesMoneyName, DateOnly DateEvent, int MaximumClientCapacity);
        Task<Event> updateTypesMoney(int TypesMoneyid, DateOnly DateEvent, string? NameTypeMoney = null, int? MaximumClientCapacity = null);
        Task<bool> deleteTypesMoney(int TypesMoneyid);
    }

    public class EventService : IEventService
    {
        private readonly IEventRepository _typeRepository;
        public EventService(IEventRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<Event> createTypesMoney(string TypesMoneyName, DateOnly DateEvent, int MaximumClientCapacity)
        {
            return await _typeRepository.CreateEvent(TypesMoneyName, DateEvent, MaximumClientCapacity);
        }

        public async Task<bool> deleteTypesMoney(int TypesMoneyid)
        {
            await _typeRepository.DeleteEvent(TypesMoneyid);
            return true;
        }

        public async Task<Event> GetTypesMoney(int TypesMoneyid)
        {
            return await _typeRepository.GetEvent(TypesMoneyid);
        }

        public async Task<List<Event>> GetTypesMoneyes()
        {
            return await _typeRepository.GetTypeMoneys();
        }

        public async Task<Event> updateTypesMoney(int TypesMoneyid, DateOnly DateEvent, string? NameTypeMoney = null, int? MaximumClientCapacity = null)
        {
            Event clase = await GetTypesMoney(TypesMoneyid);
            if (TypesMoneyid <= 0)
            {
                throw new ArgumentException("Class ID debe ser numero positivo.");
            }
            if (clase == null)
            {
                return null;
            }
            if (NameTypeMoney != null) clase.NameEvent = NameTypeMoney;
            if (MaximumClientCapacity != null) clase.MaximumClientCapacity = (int)MaximumClientCapacity;
            if (DateEvent != null) clase.DateEvent = DateEvent;

            return await _typeRepository.UpdateEvent(clase);
        }
    }
}