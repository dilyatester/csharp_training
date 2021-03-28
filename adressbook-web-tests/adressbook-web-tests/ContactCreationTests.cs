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
        public void ContactCreationtTest()
        {
            navigator.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.AddNewContact();
            contactHelper.FillContactForm(new PropertiesContact("Dilya","Shafigullina"));
            contactHelper.SubmitContactCreation();
            navigator.ReturnToHomePage();
            loginHelper.logOut();
        }

    }
}
