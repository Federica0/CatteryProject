using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace TestDomain
{
    [TestClass]
    public sealed class AdoptionTest
        //data di adozione, gatto, utente, data di fine adozione
    {
        [TestMethod]
        public void Adoption_WithCorrectValue_AssertEquals()
        {
            var Name = "gatto";
            var Gender = "maschio";
            var Breed = "Nano Persiano";
            DateOnly ArriveDate = new DateOnly(2024, 11, 24);
            DateOnly BirthDate = new DateOnly(2021, 4, 2);
            DateOnly ExitDate = new DateOnly(2025, 5, 6);
            var description = "pelo nero";
            Cat cat = new Cat(Name, Gender, Breed, description, BirthDate, ArriveDate, ExitDate);
            var name = "Mario";
            var surname = "Rossi";
            var address = "Via Roma 1";
            Phone phone = new Phone("+39", "234567890");
            var email = new Email("mario.rossi@example.com");
            var cap = new CAP(00100);
            var fiscalCode = new ItalianTaxCode("MRARSS80A01H501U");
            var user = new User(name, surname, address, phone, email, cap, fiscalCode);
            DateOnly adoptionDate = new DateOnly(2024, 14, 24);
            Adoption adoption = new Adoption(cat, user, adoptionDate);

            Assert.AreEqual(cat, adoption.AdoptionCat);
            Assert.AreEqual(user, adoption.Person);
            Assert.AreEqual(adoptionDate, adoption.AdoptionDate);
        }

    }
}
