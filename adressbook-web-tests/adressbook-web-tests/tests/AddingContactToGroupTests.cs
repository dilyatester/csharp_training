using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup() 
        {
            GroupData group = GroupData.GetAll()[0];
            List<PropertiesContact> oldList = group.GetContacts();
            PropertiesContact contact = PropertiesContact.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<PropertiesContact> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);


        }
    }
}
