using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDomain
{
    [TestClass]
    public sealed class EmailTest
    {
        [TestMethod]
        public void Constructor_ValidEmail_CreatesEmail()
        {
            Email email = new Email("gigi.gigio@gmail.com");
            Assert.AreEqual("gigi.gigio@gmail.com", email.Value);
        }

    }
}
