using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;

namespace Infrastructure.Repositories.Dto
{
    public record AdoptioinPersistenceDto
    (
        CatPersistenceDto Cat,
        UserPersistenceDto User,
        DateOnly AdoptionDate,
        DateOnly EndDate,
        bool IsFailed
    );
       
}
