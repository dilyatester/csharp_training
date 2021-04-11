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
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager)
            : base(manager)
        {

        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navigator.GoToGroupPage();

            return this;
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements) 
                {
                    groupCache.Add(new GroupData(element.Text){
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
           
            return new List<GroupData>(groupCache);
        }

        public GroupHelper Modify(int index, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(index);
            InitNewGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            manager.Navigator.GoToGroupPage();

            return this;
        }

        public GroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(index);
            RemoveGroup();
            manager.Navigator.GoToGroupPage();
            
            return this;
        }

        public bool IsExist(int index)
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]"));
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Tipe(By.Name("group_name"), group.Name);
            Tipe(By.Name("group_header"), group.Header);
            Tipe(By.Name("group_footer"), group.Footer);
            return this;
        }
         
        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitNewGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
