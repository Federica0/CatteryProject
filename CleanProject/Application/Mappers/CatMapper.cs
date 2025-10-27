using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace Application.Mappers
{
    public static class CatMapper
    {
        public static Cat ToEntity(this CatDto dto)
        {
            return new Cat(
                dto.Name,
                dto.Gender,
                dto.Breed,
                dto.Description,
                dto.BirthDate,
                dto.ArriveDate,
                dto.ExitDate
                );
        }
        public static CatDto ToDto(this Cat cat)
        {
            return new CatDto(
                cat.Name,
                cat.Gender,
                cat.Breed,
                cat.Description,
                cat.IdentificativeCode,
                cat.ArriveDate,
                cat.BirthDate,
                cat.ExitDate

                );
          
        }

    }
}
