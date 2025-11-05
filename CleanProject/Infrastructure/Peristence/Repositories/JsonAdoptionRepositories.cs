using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Model.Entities;
using Infrastructure.Repositories.Dto;

using Infrastructure.Repositories.Mapper;

namespace Infrastructure.Peristence.Repositories
{
    public class JsonAdoptionRepositories:IAdoptionRepository
    {
        private readonly string _filePath = "Adoption.json";
        private readonly Dictionary<string, Adoption> _cache = new(StringComparer.OrdinalIgnoreCase);
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
            var dtos = JsonSerializer.Deserialize<List<AdoptioinPersistenceDto>>(json) ?? new List<AdoptioinPersistenceDto>();
            foreach (var dto in dtos)
            {
                Adoption adoption = dto.ToEntity();
                string key = $"{adoption.AdoptionCat.IdentificativeCode}_{adoption.Person.FisicalCode}";
                _cache[key] = adoption;
            }
            _initialized = true;
        }
        private void SaveToFile()
        {
            var dtos = _cache.Values.Select(a => a.ToPersistenceDto()).ToList();
            var json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
        public IEnumerable<Adoption> GetAllAdoption()
        {
            EnsureLoaded();
            return _cache.Values;
        }
        public IEnumerable<Adoption>? GetAdoptionByCatCode(string code)
        {
            EnsureLoaded();
            return _cache.Values.Where(a => a.AdoptionCat.IdentificativeCode == code);
        }
        public void AddAdoption(Adoption adoption)
        {
            EnsureLoaded();
            string key = $"{adoption.AdoptionCat.IdentificativeCode}_{adoption.Person.FisicalCode}";
            if (_cache.ContainsKey(key))
                throw new InvalidOperationException("Adozione già fatta");
            _cache[key] = adoption;
            SaveToFile();
        }
        public void UpdateAdoption(Adoption adoption)
        {
            EnsureLoaded();
            string key = $"{adoption.AdoptionCat.IdentificativeCode}_{adoption.Person.FisicalCode}";
            if (!_cache.ContainsKey(key))
                throw new InvalidOperationException("Adozione non trovata per l'aggiornamento");
            _cache[key] = adoption;
            SaveToFile();
        }
        public void CancelAdoption(Adoption adoption)
        {
            EnsureLoaded();
            string key = $"{adoption.AdoptionCat.IdentificativeCode}_{adoption.Person.FisicalCode}";
            if (!_cache.ContainsKey(key))
                throw new InvalidOperationException("l'adozione non è presente all'interno del gattile");
            _cache[key] = adoption;
            SaveToFile();
        }
    }
}

