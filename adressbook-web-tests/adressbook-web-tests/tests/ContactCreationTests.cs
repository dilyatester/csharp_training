using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactCreationtTests: ContactTestBase
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

        public static IEnumerable<PropertiesContact> PropertiesContactFromXmlFile()
        {

            return (List<PropertiesContact>)
                new XmlSerializer(typeof(List<PropertiesContact>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<PropertiesContact> PropertiesContactFromJsonFile()
        {

            return JsonConvert.DeserializeObject<List<PropertiesContact>>(
                File.ReadAllText(@"contacts.json"));

        }

        [Test, TestCaseSource("PropertiesContactFromXmlFile")]
        public void ContactCreationtTest(PropertiesContact newContact)
        {
            List<PropertiesContact> oldContacts = PropertiesContact.GetAll();
            app.Contacts.Create(newContact);
            
            List<PropertiesContact> newContacts = PropertiesContact.GetAll();
            oldContacts.Add(newContact);

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);


        }

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<PropertiesContact> fromUi = app.Contacts.GetContactList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<PropertiesContact> fromDb = PropertiesContact.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

        }
    }
}
