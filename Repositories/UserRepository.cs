using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nightclub.Data;
using NightClub.Models;

namespace NightClub.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User newUser);
        Task<List<User>> GetUsers();
        Task<User> GetUser(int UserId);
        Task<User> UpdateUser(User User);
        Task<bool> DeleteUser(int UserId);
    }

    public class UserRepository : IUserRepository
    {
        private readonly DataContext _db;

        public UserRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<User> CreateUser(User newUser)
        {
            await _db.Users.AddAsync(newUser);
            await _db.SaveChangesAsync();
            return newUser;
        }

        public async Task<bool> DeleteUser(int IdUser)
        {
            var User = await GetUser(IdUser);
            _db.Users.Remove(User);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUser(int IdUser)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.IdUser == IdUser);
        }
        public async Task<List<User>> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> UpdateUser(User User)
        {
            _db.Users.Update(User);
            await _db.SaveChangesAsync();
            return User;
        }
    }
}