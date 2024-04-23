using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NightClub.Controllers;
using NightClub.Dto;
using NightClub.Models;
using NightClub.Repositories;

namespace NightClub.Services
{
    public interface IWorkerService
    {
        Task<List<Worker>> GetWorkers();
        Task<Worker> GetWorker(int WorkerId);
        Task<Worker> CreateWorker(WorkerDto WorkerDto);
        Task<bool> UpdateWorker(WorkerUpdate WorkerUpdate);
        Task<bool> DeleteWorker(int WorkerId);
    }

    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _WorkerRepository;
        private readonly IUserRepository _userRepository;


        public WorkerService(IWorkerRepository WorkerRepository, IUserRepository userRepository)
        {
            _WorkerRepository = WorkerRepository;
            _userRepository = userRepository;
        }

        public async Task<Worker> CreateWorker(WorkerDto WorkerDto)
        {
            var newUser = new User()
            {
                NameUser = WorkerDto.NameUser,
                SurnameUser = WorkerDto.SurnameUser,
                DocumentNumber = WorkerDto.DocumentNumber,
                DateOfBirth = WorkerDto.DateOfBirth,
                IdTypeDocument = WorkerDto.IdTypeDocument
            };
            newUser = await _userRepository.CreateUser(newUser);
            var newWorker = new Worker()
            {
                IdUser = newUser.IdUser,
                IdHealthcareProviders = WorkerDto.IdHealthcareProviders,
                IdTypesWorker = WorkerDto.IdTypesWorker,
                IdStatusWorker = WorkerDto.IdStatusWorker
            };
            return await _WorkerRepository.CreateWorker(newWorker);
        }

        public async Task<bool> DeleteWorker(int WorkerId)
        {
            var Worker = await GetWorker(WorkerId);
            await _WorkerRepository.DeleteWorker(WorkerId);
            await _userRepository.DeleteUser(Worker.IdUser);
            return true;
        }

        public async Task<Worker> GetWorker(int WorkerId)
        {
            return await _WorkerRepository.GetWorker(WorkerId);
        }

        public async Task<List<Worker>> GetWorkers()
        {
            return await _WorkerRepository.GetWorkers();
        }

        public async Task<bool> UpdateWorker(WorkerUpdate WorkerUpdate)
        {
            var Worker = await GetWorker(WorkerUpdate.IdWorker);
            var user = await _userRepository.GetUser(Worker.IdUser);
            if (WorkerUpdate.NameUser != null) user.NameUser = WorkerUpdate.NameUser;
            if (WorkerUpdate.SurnameUser != null) user.SurnameUser = WorkerUpdate.SurnameUser;
            if (WorkerUpdate.DateOfBirth != null) user.DateOfBirth = WorkerUpdate.DateOfBirth;
            if (WorkerUpdate.DocumentNumber != null) user.DocumentNumber = WorkerUpdate.DocumentNumber;
            if (WorkerUpdate.IdHealthcareProviders != null) Worker.IdHealthcareProviders = (int)WorkerUpdate.IdHealthcareProviders;
            if (WorkerUpdate.IdTypesWorker != null) Worker.IdTypesWorker = (int)WorkerUpdate.IdTypesWorker;
            if (WorkerUpdate.IdStatusWorker != null) Worker.IdStatusWorker = (int)WorkerUpdate.IdStatusWorker;
            await _userRepository.UpdateUser(user);
            await _WorkerRepository.UpdateWorker(Worker);
            return true;
        }
    }
}