using System;
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
            int index = 1; 

            //Если  пользователь пытается удалять первый элемент, а его нет, то мы создадим его
            if ((index == 1) && (!app.Contacts.IsExist(index)))
            {
                app.Contacts.Create(new PropertiesContact("AutoCreated", "AutoCreated"));
            }

            //Если удаляем контакт, которого нет, то тест должен провалиться
            Assert.IsTrue(app.Contacts.IsExist(index));

            app.Contacts.Remove(index);
        }
    }
}
