using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace Application.Mappers
{
    public static class UserMapper
    {
        public static User ToEntity (this User dto)
        {
            return new User(
                dto.Name,
                dto.Surname,
                dto.Address,
                dto.PhoneNumber,
                dto.Email,
                dto.Cap,
                dto.FisicalCode
                );
        }
    }
}
