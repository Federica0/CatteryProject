using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories.Dto;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;


namespace Infrastructure.Repositories.Mapper
{
    public static class UserPersistenceMapper
    {
        public static User ToEntity(this UserPersistenceDto dto)
        {
            return new User(
                dto.Name,
                dto.Surname,
                dto.Address,
                dto.City,
                new Phone(dto.Phone),
                new Email(dto.Email),
                new CAP(dto.Cap),
                new ItalianTaxCode(dto.ItalianTaxCode)
            );
        }
        public static UserPersistenceDto ToPersistenceDto(this User user)
        {
            return new UserPersistenceDto(
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
    }
}
