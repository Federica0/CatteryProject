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
            AdoptionCat.ExitDate= adoptionDate;
        }
        public void FailAdoption( DateOnly endDate)
        {            
            IsFailed = true;
            EndDate = endDate;
            AdoptionCat.ExitDate = null;
            AdoptionCat.Description = $"  Adozione fallita: iniziata{AdoptionDate: dd/MM/yyyy} terminata {EndDate: dd/MM/yyyy}";
        }
    }
}
