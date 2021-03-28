using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbookTests
{
    class GroupRemovalTests
    {
        [TestFixture]
        public class UntitledTestCase : TestBase
        {
            [Test]
            public void TheUntitledTestCaseTest()
            {
                OpenHomePage();
                Login(new AccountData("admin", "secret"));
                GoToGroupPage();
                SelectGroup(1);
                RemoveGroup();
                ReturnToGroupPage();
            }
        }
    }
}
