using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Adoption
    {
        private Cat _adoptionCat;
        public Cat AdoptionCat { get; set; } 

        private User _person;
        public User Person { get; set; }

        private DateOnly _adoptionDate;
        public DateOnly AdoptionDate { get; set; }

        private bool _isFailed;
        public DateOnly EndDate { get; set; }
        public bool IsFailed { get; set; }
        public Adoption(Cat adoptionCat, User person, DateOnly adoptionDate)
        {
            AdoptionCat = adoptionCat;
            Person = person;
            AdoptionDate = adoptionDate;
            IsFailed = false;
            adoptionCat.ExitDate= adoptionDate;
        }
        public void FailAdoption(Adoption adoptio, DateOnly endDate)
        {
            
            adoptio.IsFailed = true;
            adoptio.EndDate = endDate;
            adoptio.AdoptionCat.ExitDate = null;
            adoptio.AdoptionCat.Description = $"  Adozione fallita: iniziata{adoptio.AdoptionDate: dd/MM/yyyy} terminata {adoptio.EndDate: dd/MM/yyyy}";
        }
    }
}
