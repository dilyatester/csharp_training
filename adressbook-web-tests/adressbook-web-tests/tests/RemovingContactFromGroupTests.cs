using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<PropertiesContact> oldList = group.GetContacts();
            PropertiesContact contact = oldList.First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<PropertiesContact> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);


        }
    }
}

