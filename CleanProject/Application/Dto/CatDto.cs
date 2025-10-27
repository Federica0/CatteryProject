using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record CatDto(
    
        string Name,
        string Gender,
        string Breed,
        string? Description,
        string IdentificativeCode,
        DateOnly ArriveDate,
        DateOnly? ExitDate,
        DateOnly? BirthDate
    );
}
