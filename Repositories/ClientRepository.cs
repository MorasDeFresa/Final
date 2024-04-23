using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nightclub.Data;
using NightClub.Dto;
using NightClub.Models;

namespace NightClub.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClients();
        Task<Client> GetClient(int IdClient);
        Task<Client> CreateClient(Client newClient);
        Task<Client> UpdateClient(Client Client);
        Task<bool> DeleteClient(int IdClient);
    }

    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _db;

        public ClientRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Client> CreateClient(Client newClient)
        {
            await _db.Clients.AddAsync(newClient);
            await _db.SaveChangesAsync();
            return newClient;
        }

        public async Task<bool> DeleteClient(int IdClient)
        {
            var client = await GetClient(IdClient);
            _db.Clients.Remove(client);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Client> GetClient(int IdClient)
        {
            return await _db.Clients.FirstOrDefaultAsync(u => u.IdClient == IdClient);
        }
        public async Task<List<Client>> GetClients()
        {
            return await _db.Clients.ToListAsync();
        }

        public async Task<Client> UpdateClient(Client Client)
        {
            _db.Clients.Update(Client);
            await _db.SaveChangesAsync();
            return Client;
        }
    }
}