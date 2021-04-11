using System;
using System.Collections.Generic;
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
            PropertiesContact newContact = new PropertiesContact("Dilya", "Shafigullina");
            List<PropertiesContact> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(newContact);
            
            List<PropertiesContact> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);


        }

    }
}
