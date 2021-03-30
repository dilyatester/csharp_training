using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            PropertiesContact newData = new PropertiesContact("Dilya2", "Shafigullina2");
            app.Contacts.Modify(1,newData);
        }
    }
}