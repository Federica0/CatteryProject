using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomain
{
    [TestClass]
    public sealed class TestPhone
    {
        [TestMethod]
        public void Constructor_ValidData_CreatesPhone()
        {
            Phone phone = new Phone("+39", "1234567890");
            Assert.AreEqual("+39", phone.Prefix);
            Assert.AreEqual("1234567890", phone.Number);
        }
    }
}
