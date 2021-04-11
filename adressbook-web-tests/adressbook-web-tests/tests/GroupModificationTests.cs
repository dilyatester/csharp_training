using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests

{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            int index = 0;

            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;

            //Если  пользователь пытается удалять первый элемент, а его нет, то мы создадим его
            if ((index == 0) && (!app.Groups.IsExist(index)))
            {
                GroupData group = new GroupData("AutoCreated");
                group.Header = "AutoCreated";
                group.Footer = "AutoCreated";

                app.Groups.Create(group);
            }

            //Если правим группу, которой нет, то тест должен провалиться
            Assert.IsTrue(app.Groups.IsExist(index));

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(index, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[index].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
