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
            List<GroupData> groups = GroupData.GetAll();
            //Если групп нет, то создадим хотя бы одну и контакт в ней
            if (groups.Count < 1)
            {
                GroupData newGroup = new GroupData("TestGroupAuto");
                PropertiesContact newContact = new PropertiesContact("TestUserAuto", "TestUserAuto");

                app.Groups.Create(newGroup);
                if (PropertiesContact.GetAll().Count < 1)
                    app.Contacts.Create(newContact);
                app.Contacts.AddContactToGroup(PropertiesContact.GetAll().First(), newGroup);

                groups = GroupData.GetAll();
            }

            GroupData group = groups[0];

            List<PropertiesContact> oldList = group.GetContacts();

            //Если контакта в группе нет, то добавим его/создадим
            if (oldList.Count < 1)
            {
                PropertiesContact newContact = new PropertiesContact("TestUserAuto", "TestUserAuto");
                if (PropertiesContact.GetAll().Count < 1)
                    app.Contacts.Create(newContact);
                app.Contacts.AddContactToGroup(PropertiesContact.GetAll().First(), group);
            }    

            PropertiesContact contact = group.GetContacts().First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<PropertiesContact> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);


        }
    }
}

