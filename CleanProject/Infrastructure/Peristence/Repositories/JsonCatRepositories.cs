using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class JsonCatRepositories//implementre l'interfaccia ICatRepositories
    {
        private readonly string _filePath = "cat.json";
        private readonly Dictionary<string, Cat> _cache = new(StringComparer.OrdinalIgnoreCase);
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
            var dtos = JsonSerializer.Deserialize<List<CatPersistenceDto>>(json) ?? new List<CatPersistenceDto>();
            foreach(var dto in dtos)
            {
                Cat cat = dto.ToEntity();
                _cache[cat.IdentificativeCode] = cat;
            }
            _initialized = true;
        }
    }

}

