using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NightClub.Controllers;
using NightClub.Dto;
using NightClub.Models;
using NightClub.Repositories;

namespace NightClub.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetClients();
        Task<Client> GetClient(int ClientId);
        Task<Client> CreateClient(ClientDto clientDto);
        Task<bool> UpdateClient(ClientUpdate clientUpdate);
        Task<bool> DeleteClient(int ClientId);
    }

    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserRepository _userRepository;


        public ClientService(IClientRepository clientRepository, IUserRepository userRepository)
        {
            _clientRepository = clientRepository;
            _userRepository = userRepository;
        }

        public async Task<Client> CreateClient(ClientDto clientDto)
        {
            var newUser = new User()
            {
                NameUser = clientDto.NameUser,
                SurnameUser = clientDto.SurnameUser,
                DocumentNumber = clientDto.DocumentNumber,
                DateOfBirth = clientDto.DateOfBirth,
                IdTypeDocument = clientDto.IdTypeDocument
            };
            newUser = await _userRepository.CreateUser(newUser);
            var newClient = new Client()
            {
                IdUser = newUser.IdUser,
                EmailClient = clientDto.EmailClient,
                PasswordClient = clientDto.PasswordClient
            };
            return await _clientRepository.CreateClient(newClient);
        }

        public async Task<bool> DeleteClient(int ClientId)
        {
            var client = await GetClient(ClientId);
            await _clientRepository.DeleteClient(ClientId);
            await _userRepository.DeleteUser(client.IdUser);
            return true;
        }

        public async Task<Client> GetClient(int ClientId)
        {
            return await _clientRepository.GetClient(ClientId);
        }

        public async Task<List<Client>> GetClients()
        {
            return await _clientRepository.GetClients();
        }

        public async Task<bool> UpdateClient(ClientUpdate clientUpdate)
        {
            var client = await GetClient(clientUpdate.IdClient);
            var user = await _userRepository.GetUser(client.IdUser);
            if (clientUpdate.NameUser != null) user.NameUser = clientUpdate.NameUser;
            if (clientUpdate.SurnameUser != null) user.SurnameUser = clientUpdate.SurnameUser;
            if (clientUpdate.DateOfBirth != null) user.DateOfBirth = clientUpdate.DateOfBirth;
            if (clientUpdate.DocumentNumber != null) user.DocumentNumber = clientUpdate.DocumentNumber;
            if (clientUpdate.EmailClient != null) client.EmailClient = clientUpdate.EmailClient;
            if (clientUpdate.PasswordClient != null) client.PasswordClient = clientUpdate.PasswordClient;
            await _userRepository.UpdateUser(user);
            await _clientRepository.UpdateClient(client);
            return true;
        }
    }
}