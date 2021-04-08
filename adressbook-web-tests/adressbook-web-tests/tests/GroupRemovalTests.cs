using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int index = 1;
            //Если  пользователь пытается удалять первый элемент, а его нет, то мы создадим его
            if ((index == 1) && (!app.Groups.IsExist(index)))
            {
                GroupData group = new GroupData("AutoCreated");
                group.Header = "AutoCreated";
                group.Footer = "AutoCreated";

                app.Groups.Create(group);
            }
            //Если удаляем группу, которой нет, то тест должен провалиться
            Assert.IsTrue(app.Groups.IsExist(index));

            app.Groups.Remove(index);
        }
    }
}
