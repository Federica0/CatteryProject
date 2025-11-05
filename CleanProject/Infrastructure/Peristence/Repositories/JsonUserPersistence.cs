using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Model.Entities;
using Infrastructure.Repositories.Dto;
using Infrastructure.Repositories.Mapper;

namespace Infrastructure.Peristence.Repositories
{
    public class JsonUserPersistence:IUserRepository
    {
        private readonly string _filePath = "User.json";
        private readonly Dictionary<string, User> _cache = new(StringComparer.OrdinalIgnoreCase);
        private bool _initialized = false;
        private void EnsureLoaded()
        {
            if (_initialized) return;
            if (!File.Exists(_filePath))
            {
                _initialized = true;
                return;
            }
            var json = File.ReadAllText(_filePath);
            var dtos = JsonSerializer.Deserialize<List<UserPersistenceDto>>(json) ?? new List<UserPersistenceDto>();
            foreach (var dto in dtos)
            {
                User person = dto.ToEntity();
                string key = $"{person.FisicalCode}";
                _cache[key] = person;
            }
            _initialized = true;
        }
        private void SaveToFile()
        {
            var dtos = _cache.Values.Select(a => a.ToPersistenceDto()).ToList();
            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
        public void AddUser(User user)
        {
            EnsureLoaded();
            if (_cache.ContainsKey(user.FisicalCode.Value))
                throw new InvalidOperationException($"L'utente '{user.FisicalCode}' è gia presente all'interno del gattile");
            _cache[user.FisicalCode.Value] = user;
            SaveToFile();      
        }
        public void DeleteUser(User user)
        {
            if (!_cache.ContainsKey(user.FisicalCode.Value)) 
                throw new InvalidOperationException($"L'utente '{user.FisicalCode}' non è presente all'interno del gattile");
            _cache[user.FisicalCode.Value] = user;
            SaveToFile();
        }
        public IEnumerable<User> GetAllUsers()
        {
            EnsureLoaded();
            return _cache.Values;
        }
        public 
    }
}
