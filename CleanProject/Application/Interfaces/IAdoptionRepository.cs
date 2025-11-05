using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;


namespace Application.Interfaces
{
    public interface IAdoptionRepository
    {
        IEnumerable<Adoption> GetAllAdoption();
        IEnumerable<Adoption>? GetAdoptionByCatCode(String code);
        void AddAdoption(Adoption adoption);
        void UpdateAdoption(Adoption adoption); 
        void CancelAdoption(Adoption adoption);
    }
}
