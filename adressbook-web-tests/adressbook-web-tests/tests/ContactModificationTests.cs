using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            int index = 1;
            PropertiesContact newData = new PropertiesContact("Dilya3", "Shafigullina3");

            //Если  пользователь пытается удалять первый элемент, а его нет, то мы создадим его
            if ((index == 1) && (!app.Contacts.IsExist(index)))
            {
                app.Contacts.Create(new PropertiesContact("AutoCreated", "AutoCreated"));
            }

            //Если правим контакт, которого нет, то тест должен провалиться
            Assert.IsTrue(app.Contacts.IsExist(index));

            app.Contacts.Modify(index, newData);
        }
    }
}