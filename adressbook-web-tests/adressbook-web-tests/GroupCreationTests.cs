﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupCreationTests:TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupPage();
            InitNewGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "ddd"; 
            group.Footer = "fff";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
        }
    }
}
