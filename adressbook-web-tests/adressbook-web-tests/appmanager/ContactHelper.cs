using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
            manager.Navigator.ReturnToHomePage();
            manager.Auth.logOut();
            return this;
        }

        public ContactHelper Remove(int i)
        {
            manager.Navigator.ReturnToHomePage();
            SelectContact(i);
            RemoveContact();
            manager.Navigator.ReturnToHomePage();

            return this;
        }

        public ContactHelper Modify(int index, PropertiesContact newData)
        {
            manager.Navigator.OpenHomePage();
            SelectContact(index);
            FillContactForm(newData);
            SubmitUpdateModification();
            manager.Navigator.ReturnToHomePage();

            return this;
        }

        public ContactHelper SubmitUpdateModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper ModifyContact()
        {
            //driver.FindElement(By.XPath("//input[@name='update'])[2]")).Click();
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            //driver.FindElement(By.Name("modifiy")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(PropertiesContact contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
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
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }
    }
}
