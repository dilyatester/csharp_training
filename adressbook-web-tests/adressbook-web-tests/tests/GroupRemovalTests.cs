using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int index = 0;
            //Если  пользователь пытается удалять первый элемент, а его нет, то мы создадим его
            if ((index == 0) && (!app.Groups.IsExist(index)))
            {
                GroupData group = new GroupData("AutoCreated");
                group.Header = "AutoCreated";
                group.Footer = "AutoCreated";

                app.Groups.Create(group);
            }
            //Если удаляем группу, которой нет, то тест должен провалиться
            Assert.IsTrue(app.Groups.IsExist(index));

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(index);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(index);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
