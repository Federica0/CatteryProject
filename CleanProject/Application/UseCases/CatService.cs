using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Domain.Model.Entities;

namespace Application.UseCases
{
    public class CatService
    {
        private readonly ICatRepository _repositoryCat;
        private readonly IAdoptionRepository _repositoryAdoption;
        public CatService(ICatRepository repository,IAdoptionRepository repositoryAdoption)
        {
            _repositoryCat = repository;
            _repositoryAdoption = repositoryAdoption;
        }

        public void AddCat(CatDto catDto) {
            
            Cat cat = catDto.ToEntity();
            _repositoryCat.AddCat(cat);
        }

        public void DeleteCat(string code){            
            //se c'è recupero dalla persistenza l'oggetto cat e chiamo il delete sulla persistenza
            Cat? cat = _repositoryCat.GetCatByCode(code);
            if (cat != null) {
                _repositoryCat.DeletCat(cat);
            }
            else {
                throw new NullReferenceException($"cat whit code ︃{code} not exists");
            }        
        }

        public void AdoptCat(string catCode, UserDto userDto) {
            //inserisciuna adozione per il gatto e aggiorni i valori del gatto
            Cat? cat = _repositoryCat.GetCatByCode(catCode);
            User user = userDto.ToEntity();

            //creo una nuova a dozione per cat, user con la data di oggi --> ho anche aggironato la exit date del gatto
            Adoption adoption = new Adoption(cat, user, DateOnly.FromDateTime( DateTime.Now));
            //rendo l'adozione persistente
            _repositoryAdoption.AddAdoption(adoption);
            //rendo persistente la modifica sul cat
            _repositoryCat.UpdateCat(cat.IdentificativeCode);

        }

    }
}
