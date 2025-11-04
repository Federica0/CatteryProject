
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;


namespace TestDomain
{
    [TestClass]
    public sealed class UserTest
    {
        [TestMethod]
        public void Constructor_ValidInput_PropertiesInitializedCorrectly()
        {

            var name = "Mario";
            var surname = "Rossi";
            var address = "Via Roma 1";
            Phone phone = new Phone("+39234567890");
            var email = new Email("mario.rossi@example.com");
            var cap = new CAP(00100);
            var fiscalCode = new ItalianTaxCode("MRARSS80A01H501U");
            var city = "Cesena";
            var user = new User(name, surname, address,city, phone, email, cap, fiscalCode);

            Assert.AreEqual(name, user.Name);
            Assert.AreEqual(surname, user.Surname);
            Assert.AreEqual(address, user.Address);
            Assert.AreEqual(phone, user.PhoneNumber);
            Assert.AreEqual(email, user.Email);
            Assert.AreEqual(cap, user.Cap);
            Assert.AreEqual(fiscalCode, user.FisicalCode);
        }
    }
}

