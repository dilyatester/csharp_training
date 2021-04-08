using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace WebAdressbookTests
{
    public class ContactHelper: HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {

        }


        public ContactHelper Create(PropertiesContact propertiesContact)
        {
            AddNewContact();
            FillContactForm(propertiesContact);
            SubmitContactCreation();
            manager.Navigator.OpenHomePage();
            //manager.Auth.Logout();
            return this;
        }

        public ContactHelper Remove(int index)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(index);
            RemoveContact();
            manager.Navigator.OpenHomePage();

            return this;
        }

        public ContactHelper Modify(int index, PropertiesContact newData)
        {
            manager.Navigator.OpenHomePage();
            ModifyContact(index);
            FillContactForm(newData);
            SubmitUpdateModification();
            manager.Navigator.OpenHomePage();
            
            return this;
        }

        public bool IsExist(int index)
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]"));
        }

        public ContactHelper SubmitUpdateModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper ModifyContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(PropertiesContact contact)
        {
            Tipe(By.Name("firstname"), contact.Firstname);
            Tipe(By.Name("lastname"), contact.Lastname);
            return this;
        }

        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;

        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
    }
}
