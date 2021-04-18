using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAdressbookTests 
{
    [TestFixture]
    public class ContactInformationTests: AuthTestBase 
    {
        [Test]
        public void TestContactInformation() 
        {
            PropertiesContact fromTable = app.Contacts.GetContactInformationFromTable(0);
            PropertiesContact fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            PropertiesContact fromDetails = app.Contacts.GetContactInformationFromDetails(0);

            // проверки для таблицы и формы
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Adress, fromForm.Adress);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromForm.AllDetails, fromDetails.AllDetails);
        }
    }
}
   