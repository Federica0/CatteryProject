﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;


namespace Application.Interfaces
{
    public interface IAdoptionRepository
    {
        void Adoption(Adoption adoption);
        void FailAdoption(Adoption adoptio, DateOnly endDate);
    }
}
