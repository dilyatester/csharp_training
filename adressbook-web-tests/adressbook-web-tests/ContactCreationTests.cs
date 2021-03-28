using System;
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
    public class ContactCreationtTests:TestBase
    {
        [Test]
        public void TheUntitledTestCaseTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            AddNewContact();
            FillContactForm(new PropertiesContact("Dilya","Shafigullina"));
            SubmitContactCreation();
            ReturnToHomePage();
            logOut();
        }

    }
}
