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
        public static IEnumerable<PropertiesContact> RandomPropertiesContactProvider()
        {
            List<PropertiesContact> contacts = new List<PropertiesContact>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new PropertiesContact(GenerateRandomString(30), GenerateRandomString(30)));
            }
            return contacts;
        }



        [Test, TestCaseSource("RandomPropertiesContactProvider")]
        public void ContactCreationtTest(PropertiesContact newContact)
        {
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
