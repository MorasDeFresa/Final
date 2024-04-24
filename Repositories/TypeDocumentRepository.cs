using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nightclub.Data;
using NightClub.Models;

namespace NightClub.Repositories
{
    public interface ITypeDocumentRepository
    {
        Task<List<TypeDocument>> GetTypeMoneys();
        Task<TypeDocument> GetTypeMoney(int TypeMoneyId);
        Task<TypeDocument> CreateTypeMoney(string TypeMoneyName);
        Task<TypeDocument> UpdateTypeMoney(TypeDocument typesMoney);
        Task<bool> DeleteTypeMoney(int TypeMoneyId);
    }

    public class TypeDocumentRepository : ITypeDocumentRepository
    {
        private readonly DataContext _db;

        public TypeDocumentRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<TypeDocument> CreateTypeMoney(string TypeMoneyName)
        {
            var newTypeMoney = new TypeDocument()
            {
                NameTypeDocument = TypeMoneyName,
            };

            await _db.TypeDocuments.AddAsync(newTypeMoney);
            _db.SaveChanges();
            return newTypeMoney;
        }
        public async Task<List<TypeDocument>> GetTypeMoneys()
        {
            return await _db.TypeDocuments.ToListAsync();
        }

        public async Task<TypeDocument> GetTypeMoney(int TypeMoneyId)
        {
            return await _db.TypeDocuments.FirstOrDefaultAsync(u => u.IdTypeDocument == TypeMoneyId);
        }

        public async Task<TypeDocument> UpdateTypeMoney(TypeDocument typesMoney)
        {
            _db.TypeDocuments.Update(typesMoney);
            await _db.SaveChangesAsync();
            return typesMoney;
        }

        public async Task<bool> DeleteTypeMoney(int TypeMoneyId)
        {
            var type = await GetTypeMoney(TypeMoneyId);
            _db.TypeDocuments.Remove(type);
            await _db.SaveChangesAsync();
            return true;
        }

    }
}