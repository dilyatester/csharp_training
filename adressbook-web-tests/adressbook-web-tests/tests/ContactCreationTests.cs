using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactCreationtTests: AuthTestBase
    {
        [Test]
        public void ContactCreationtTest()
        {
            app.Contacts.Create(new PropertiesContact("Dilya", "Shafigullina"));
           
        }

    }
}
