using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Domain.Model.Entities;
using Infrastructure.Repositories.Dto;

namespace Infrastructure.Repositories.Mapper
{
    public static class AdoptionPersistenceMapper
    {
        public static Adoption ToEntity(this AdoptioinPersistenceDto dto)
        {
            return new Adoption(
                dto.Cat.ToEntity(),
                dto.User.ToEntity(),
                dto.AdoptionDate
                );
        }
        public static AdoptioinPersistenceDto ToPersistenceDto(this Adoption adoption)
        {
            return new AdoptioinPersistenceDto(
                adoption.AdoptionCat.ToPersistenceDto(),
                adoption.Person.ToPersistenceDto(),
                adoption.AdoptionDate,
                adoption.EndDate,
                adoption.IsFailed
                );
        }
    }
}
