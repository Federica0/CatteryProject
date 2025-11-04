using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Dto
{
    public record UserPersistenceDto
    (
         string Name,
        string Surname,
        string Address,
        string City,
        string Phone,
        string Email,
        int Cap,
        string ItalianTaxCode
    );

    
}
