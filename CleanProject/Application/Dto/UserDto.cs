﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    string CAP,
    string ItalianTaxCode
        
    );
    
}
