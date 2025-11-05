using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace Application.Mappers
{
    public static class AdoptionMapper
    {
        public static Adoption ToEntity(this AdoptionDto dto)
        {
            return new Adoption(
                dto.Cat.ToEntity(),
                dto.User.ToEntity(),
                dto.AdoptionDate,
                dto.IsFailed,
                dto.EndDate
                );
        }
        public static AdoptionDto ToDto(this Adoption adoption)
        {
            return new AdoptionDto(
                adoption.AdoptionCat.ToDto(),
                adoption.Person.ToDto(),
                adoption.AdoptionDate,
                adoption.EndDate,
                adoption.IsFailed
                );
        }
    }
}
