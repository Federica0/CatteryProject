using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories.Dto;
using Domain.Model.Entities;

namespace Infrastructure.Repositories.Mapper
{
    public static class CatPersistenceMapper
    {
        public static CatPersistenceDto ToPersistenceDto(this Cat cat)
        {
            return new CatPersistenceDto(
                cat.Name,
                cat.Gender,
                cat.Breed,
                cat.Description,
                cat.IdentificativeCode,
                cat.ArriveDate,
                cat.ExitDate,
                cat.BirthDate
                );
        }
        public  static Cat ToEntity(this CatPersistenceDto dto)
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
    }
}
