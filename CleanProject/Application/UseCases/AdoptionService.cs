using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class AdoptionService
    {
        private readonly ICatRepository _repositoryCat;
        private readonly IAdoptionRepository _repositoryAdoption;
        public AdoptionService(ICatRepository repository, IAdoptionRepository repositoryAdoption)
        {
            _repositoryCat = repository;
            _repositoryAdoption = repositoryAdoption;
        }

        public void RefundCat(AdoptionDto adoptionDto, DateOnly date) {
            //trasfromo il dto in oggetto adozione
            Adoption adoption = adoptionDto.ToEntity();

            //sull'oggetto chioamo il metodo che gestisce il fallimento dell'adozione --> fa le modifiche anche al cat
            adoption.FailAdoption(date);

            //rendo persistenti le modifiche
            _repositoryAdoption.UpdateAdoption(adoption);
            _repositoryCat.UpdateCat(adoption.AdoptionCat.IdentificativeCode);
        }

    }
}
