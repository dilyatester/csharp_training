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
            List<GroupData> groups = GroupData.GetAll();

            //Если групп нет, то создадим хотя бы одну
            if (groups.Count < 1)
            {
                app.Groups.Create(new GroupData("TestGroupAuto"));

                groups = GroupData.GetAll();
            } 
                
            GroupData group = groups[0]; //получаем первую группу 

            List<PropertiesContact> oldList = group.GetContacts();
            IEnumerable<PropertiesContact> contactsNotInGroup = PropertiesContact.GetAll().Except(oldList);

            //Если контактов, которых нет в группе нет, то создадим новый
            if (contactsNotInGroup.Count() < 1)
            {
                app.Contacts.Create(new PropertiesContact("TestUserAuto", "TestUserAuto"));
            }

            //Получаем все контакты
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
