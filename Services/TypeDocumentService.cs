using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NightClub.Models;
using NightClub.Repositories;

namespace NightClub.Services
{
    public interface ITypeDocumentService
    {
        Task<List<TypeDocument>> GetTypesMoneyes();
        Task<TypeDocument> GetTypesMoney(int TypesMoneyid);
        Task<TypeDocument> createTypesMoney(string? TypesMoneyName = null);
        Task<TypeDocument> updateTypesMoney(int TypesMoneyid, string? TypesMoneyName = null);
        Task<bool> deleteTypesMoney(int TypesMoneyid);
    }

    public class TypeDocumentService : ITypeDocumentService
    {
        private readonly ITypeDocumentRepository _typeRepository;
        public TypeDocumentService(ITypeDocumentRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<TypeDocument> createTypesMoney(string? TypesMoneyName = null)
        {
            return await _typeRepository.CreateTypeMoney(TypesMoneyName);
        }

        public async Task<bool> deleteTypesMoney(int TypesMoneyid)
        {
            await _typeRepository.DeleteTypeMoney(TypesMoneyid);
            return true;
        }

        public async Task<TypeDocument> GetTypesMoney(int TypesMoneyid)
        {
            return await _typeRepository.GetTypeMoney(TypesMoneyid);
        }

        public async Task<List<TypeDocument>> GetTypesMoneyes()
        {
            return await _typeRepository.GetTypeMoneys();
        }

        public async Task<TypeDocument> updateTypesMoney(int TypesMoneyid, string? NameTypeMoney = null)
        {
            TypeDocument clase = await GetTypesMoney(TypesMoneyid);
            if (TypesMoneyid <= 0)
            {
                throw new ArgumentException("Class ID debe ser numero positivo.");
            }
            if (clase == null)
            {
                return null;
            }
            if (NameTypeMoney != null)
            {
                clase.NameTypeDocument = NameTypeMoney;
            }
            return await _typeRepository.UpdateTypeMoney(clase);
        }
    }
}