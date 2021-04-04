using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            PropertiesContact newData = new PropertiesContact("Dilya3", "Shafigullina3");
            app.Contacts.Modify(2,newData);
        }
    }
}