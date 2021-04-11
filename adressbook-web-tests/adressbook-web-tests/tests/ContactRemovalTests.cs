using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int index = 0; 

            //Если  пользователь пытается удалять первый элемент, а его нет, то мы создадим его
            if ((index == 0) && (!app.Contacts.IsExist(index)))
            {
                app.Contacts.Create(new PropertiesContact("AutoCreated", "AutoCreated"));
            }

            //Если удаляем контакт, которого нет, то тест должен провалиться
            Assert.IsTrue(app.Contacts.IsExist(index));

            List<PropertiesContact> oldContacts = app.Contacts.GetContactList();
            PropertiesContact toBeRemoved = oldContacts[index];
            app.Contacts.Remove(index);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<PropertiesContact> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(index);

            Assert.AreEqual(oldContacts, newContacts);

            //Проверка, что не существует Id который мы уже удалили
            foreach (PropertiesContact contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
