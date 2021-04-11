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

        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name = 'entry']")).Count;
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


        private List<PropertiesContact> contactCache = null;

        public List<PropertiesContact> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<PropertiesContact>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name = 'entry']"));
                foreach (IWebElement element in elements)
                {
                    ICollection<IWebElement> td = element.FindElements(By.CssSelector("td"));
                    contactCache.Add(new PropertiesContact(td.ElementAt(2).Text, td.ElementAt(1).Text){
                        Id = td.ElementAt(0).FindElement(By.TagName("input")).GetAttribute("id")
                    });
                }
            }
            return new List<PropertiesContact>(contactCache);
        }

        public bool IsExist(int index)
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]"));
        }

        public ContactHelper SubmitUpdateModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ModifyContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (index+1) + "]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
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
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }
    }
}
