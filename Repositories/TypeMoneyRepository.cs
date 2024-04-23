using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nightclub.Data;
using NightClub.Models;

namespace NightClub.Repositories
{
    public interface ITypeMoneyRepository
    {
        Task<List<TypeMoney>> GetTypeMoneys();
        Task<TypeMoney> GetTypeMoney(int TypeMoneyId);
        Task<TypeMoney> CreateTypeMoney(string TypeMoneyName);
        Task<TypeMoney> UpdateTypeMoney(TypeMoney typesMoney);
        Task<bool> DeleteTypeMoney(int TypeMoneyId);
    }

    public class TypeMoneyRepository : ITypeMoneyRepository
    {
        private readonly DataContext _db;

        public TypeMoneyRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<TypeMoney> CreateTypeMoney(string TypeMoneyName)
        {
            var newTypeMoney = new TypeMoney()
            {
                NameTypeMoney = TypeMoneyName,
            };

            await _db.TypeMoneys.AddAsync(newTypeMoney);
            _db.SaveChanges();
            return newTypeMoney;
        }
        public async Task<List<TypeMoney>> GetTypeMoneys()
        {
            return await _db.TypeMoneys.ToListAsync();
        }

        public async Task<TypeMoney> GetTypeMoney(int TypeMoneyId)
        {
            return await _db.TypeMoneys.FirstOrDefaultAsync(u => u.IdTypeMoney == TypeMoneyId);
        }

        public async Task<TypeMoney> UpdateTypeMoney(TypeMoney typesMoney)
        {
            _db.TypeMoneys.Update(typesMoney);
            await _db.SaveChangesAsync();
            return typesMoney;
        }

        public async Task<bool> DeleteTypeMoney(int TypeMoneyId)
        {
            var type = await GetTypeMoney(TypeMoneyId);
            _db.TypeMoneys.Remove(type);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}