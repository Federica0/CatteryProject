using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomain
{
    [TestClass]
    public sealed class CAPTest
    {
        [TestMethod]
        public void CAP_ValidCAP_AssertAreEquals()
        {

            int validCapValue = 12345;

            var cap = new CAP(validCapValue);
            Assert.AreEqual(validCapValue, cap.Value);
        }

        [TestMethod]
        public void CAP_InvalidCAP_ThrowsArgumentOutOfRangeException()
        {

            int invalidCapValueLow = 9999;
            int invalidCapValueHigh = 100000;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new CAP(invalidCapValueLow));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new CAP(invalidCapValueHigh));
        }
    }
}

