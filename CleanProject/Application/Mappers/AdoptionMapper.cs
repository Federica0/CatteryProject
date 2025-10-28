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
        public static Adoption ToEntity (this Adoption dto)
        {
            return new Adoption(
                dto.AdoptionCat,
                dto.Person,
                dto.AdoptionDate
                );
        }

        /*public static User ToEntity (this UserDto dto)
    {
        return new User(
            dto.Name,
            dto.Surname,
            dto.Address,
            new Phone(dto.Phone),
            new Email(dto.Email),
            new CAP(dto.Cap),
            new ItalianTaxCode(dto.ItalianTaxCode)
            );
    }
    public static UserDto ToDto(this User user)
    {
        return new UserDto(
            user.Name,
            user.Surname,
            user.Address,
            user.City,
            user.PhoneNumber.Value,
            user.Email.Value,
            user.Cap.Value,
            user.FisicalCode.Value
            );
    }
         */
    }
}
