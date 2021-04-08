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
            int index = 1;

            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;

            //Если  пользователь пытается удалять первый элемент, а его нет, то мы создадим его
            if ((index == 1) && (!app.Groups.IsExist(index)))
            {
                GroupData group = new GroupData("AutoCreated");
                group.Header = "AutoCreated";
                group.Footer = "AutoCreated";

                app.Groups.Create(group);
            }

            //Если правим группу, которой нет, то тест должен провалиться
            Assert.IsTrue(app.Groups.IsExist(index));

            app.Groups.Modify(index, newData);
        }
    }
}
