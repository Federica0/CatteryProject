using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Infrastructure.Repositories.Dto;
using Infrastructure.Repositories.Mapper;

namespace Infrastructure.Peristence.Repositories
{
    public class JsonUserPersistence//iplementezione della interfaccia
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
                //_cache[person] = person;
            }
            _initialized = true;
        }
    }
}
