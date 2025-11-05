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
    public class JsonCatRepositories:ICatRepository
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
                string key = $"{cat.IdentificativeCode}";
                _cache[key] = cat;
            }
            _initialized = true;
        }
        private void SaveToFile()
        {
            var dtos = _cache.Values.Select(a => a.ToPersistenceDto()).ToList();
            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText(_filePath, json);
        }
        public void AddCat(Cat cat)
        {
            EnsureLoaded();
            if (!_cache.ContainsKey(cat.IdentificativeCode))
                throw new InvalidOperationException($"Gatto '{cat.IdentificativeCode}' già presente nel gattile.");
            _cache[cat.IdentificativeCode] = cat;
            SaveToFile();
        }
        public void DeleteCat(Cat cat)
        {
            EnsureLoaded();
            if (!_cache.Remove(cat.IdentificativeCode))
                throw new InvalidOperationException($"Il gatto '{cat.IdentificativeCode}' non trovato per la rimozione");
            SaveToFile();
        }
        public void DeleteCat(string code)
        {
            EnsureLoaded();
            if (_cache.Remove(code))
                throw new InvalidOperationException("gatto non trovato per la rimozione");
            SaveToFile();
            
        }
        public void UpdateCat(Cat cat)
        {
            EnsureLoaded();
            if (!_cache.ContainsKey(cat.IdentificativeCode))
            {
                throw new InvalidOperationException("Gatto non trovato per l'aggiornamento");
            }
            _cache[cat.IdentificativeCode] = cat;
            SaveToFile();
        }
        public Cat? GetCatByCode(string code)
        {
            EnsureLoaded();
            Cat? cat;
            _cache.TryGetValue(code, out cat);
            return cat;
        }
        public IEnumerable<Cat> GetAllCats()
        {
            EnsureLoaded();
            return _cache.Values;
        }


    }

}

