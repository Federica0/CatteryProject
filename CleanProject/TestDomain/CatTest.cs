using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Linq;
using Domain.Model.Entities;

namespace TestDomain
{
    [TestClass]
    public sealed class CatTest
    {
        [TestMethod]
        public void Cat_WithValidDate_AssertEquals()
        {
            
            var Name = "gatto";
            var Gender = "maschio";
            var Breed = "Nano Persiano";
            DateOnly ArriveDate = new DateOnly(2024, 11, 24);
            DateOnly BirthDate = new DateOnly(2021, 4, 2);
            DateOnly ExitDate = new DateOnly(2025, 5, 6);
            var description = "pelo nero";

            Cat cat = new Cat(Name, Gender, Breed, description, BirthDate, ArriveDate, ExitDate);
            Assert.AreEqual(Name, cat.Name);
            Assert.AreEqual(Gender, cat.Gender);
            Assert.AreEqual(Breed, cat.Breed);
            Assert.AreEqual(description, cat.Description);
            Assert.AreEqual(BirthDate, cat.BirthDate);
            Assert.AreEqual(ArriveDate, cat.ArriveDate);
            Assert.AreEqual(ExitDate, cat.ExitDate);
        }

        [TestMethod]
        public void Cat_WhenTheNameIsEmpty_RetunrArgumentException()
        {
            var Name = "";
            var Gender = "maschio";
            var Breed = "Nano Persiano";
            DateOnly ArriveDate = new DateOnly(2024, 11, 24);
            DateOnly BirthDate = new DateOnly(2021, 4, 2);
            DateOnly ExitDate = new DateOnly(2025, 5, 6);
            var Description = "pelo nero";
            Assert.ThrowsException<ArgumentException>(() => new Cat (Name, Gender, Breed, Description, BirthDate, ArriveDate, ExitDate));
        }
        [TestMethod]
        public void Cat_WhenTheGenderIsEmpty_ReturnArgumetException()
        {
            var Name = "Nano";
            var Gender = "";
            var Breed = "Nano Persiano";
            DateOnly ArriveDate = new DateOnly(2024, 11, 24);
            DateOnly BirthDate = new DateOnly(2021, 4, 2);
            DateOnly ExitDate = new DateOnly(2025, 5, 6);
            var Description = "pelo nero";
            Assert.ThrowsException<ArgumentException>(() => new Cat(Name, Gender, Breed, Description, BirthDate, ArriveDate, ExitDate));

        }
        [TestMethod]
        public void Cat_WhenTheBreedIsEmpty_ReturnArgumentException()
        {
            var Name = "Nano";
            var Gender = "maschio";
            var Breed = "";
            DateOnly ArriveDate = new DateOnly(2024, 11, 24);
            DateOnly BirthDate = new DateOnly(2021, 4, 2);
            DateOnly ExitDate = new DateOnly(2025, 5, 6);
            var Description = "pelo nero";
            Assert.ThrowsException<ArgumentException>(() => new Cat(Name, Gender, Breed, Description, BirthDate, ArriveDate, ExitDate));

        }
        [TestMethod]
        public void Cat_WhenBirthDateIsGreaterThenArriveDateAndExitDate_RetunrArgumenteException()
        {
            var Name = "gatto";
            var Gender = "maschio";
            var Breed = "Nano Persiano";
            DateOnly ArriveDate = new DateOnly(2024, 11, 24);
            DateOnly BirthDate = new DateOnly(2026, 4, 2);
            DateOnly ExitDate = new DateOnly(2025, 5, 6);
            var Description = "pelo nero";
            Assert.ThrowsException<ArgumentException>(() => new Cat(Name, Gender, Breed, Description, BirthDate, ArriveDate, ExitDate));
        }
        [TestMethod]
        public void Cat_WhenTheArriveDateIsLessThanBirthDate_ReturnArgumentException()
        {
            var Name = "gatto";
            var Gender = "maschio";
            var Breed = "Nano Persiano";
            DateOnly ArriveDate = new DateOnly(2022, 11, 24);
            DateOnly BirthDate = new DateOnly(2023, 4, 2);
            DateOnly ExitDate = new DateOnly(2025, 5, 6);
            var Description = "pelo nero";
            Assert.ThrowsException<ArgumentException>(() => new Cat(Name, Gender, Breed, Description, BirthDate, ArriveDate, ExitDate));
        }
        [TestMethod]
        public void Cat_WhenTheArriveDateIsGreaterThanExitDate_ReturnArgumentException()
        {
            var Name = "gatto";
            var Gender = "maschio";
            var Breed = "Nano Persiano";
            DateOnly ArriveDate = new DateOnly(2024, 11, 24);
            DateOnly BirthDate = new DateOnly(2019, 4, 2);
            DateOnly ExitDate = new DateOnly(2023, 5, 6);
            var Description = "pelo nero";
            Assert.ThrowsException<ArgumentException>(() => new Cat(Name, Gender, Breed, Description, BirthDate, ArriveDate, ExitDate));
        }
    }
}
