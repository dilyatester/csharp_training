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
using System.Text.RegularExpressions;

namespace WebAdressbookTests
{
    public class ContactHelper: HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {

        }

        public PropertiesContact GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new PropertiesContact(firstName, lastName)
            {
                Adress = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
           
        }

        internal PropertiesContact GetContactInformationFromDetails(int index)
        {
            manager.Navigator.OpenHomePage();
            DetailsContact(index);
            string allDetails = driver.FindElement(By.Id("content")).Text;

            return new PropertiesContact("", "")
            {
                AllDetails = allDetails
            };

        }

        public PropertiesContact GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            ModifyContact(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");

            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            string birthday = (new SelectElement(driver.FindElement(By.Name("bday")))).SelectedOption.Text;
            string birthmonth = (new SelectElement(driver.FindElement(By.Name("bmonth")))).SelectedOption.Text;
            string birthyear = driver.FindElement(By.Name("byear")).GetAttribute("value");

            string anniversaryday = (new SelectElement(driver.FindElement(By.Name("aday")))).SelectedOption.Text;
            string anniversarymonth = (new SelectElement(driver.FindElement(By.Name("amonth")))).SelectedOption.Text;
            string anniversaryyear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            string adress2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string home = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");


            return new PropertiesContact(firstName, lastName)
            {
            Middlename = middlename,
            Nickname = nickname,
            Company = company,
            Title = title,
            Adress = address,
            HomePhone = homePhone,
            MobilePhone = mobilePhone,
            WorkPhone = workPhone,
            Fax = fax,
            Email = email,
            Email2 = email2,
            Email3 = email3,
            Homepage = homepage,
            Birthday = birthday,
            Birthmonth = birthmonth,
            Birthyear = birthyear,
            Anniversaryday = anniversaryday,
            Anniversarymonth = anniversarymonth,
            Anniversaryyear = anniversaryyear,
            Adress2 = adress2,
            Home = home,
            Notes = notes
            };


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

        public ContactHelper DetailsContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + "]")).Click();
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

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.OpenHomePage();
            string text = driver.FindElement(By.Id("search_count")).Text;
            return Int32.Parse(text);
        }

    }
}
