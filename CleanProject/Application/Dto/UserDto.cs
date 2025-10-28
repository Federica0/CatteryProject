using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record UserDto(

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
