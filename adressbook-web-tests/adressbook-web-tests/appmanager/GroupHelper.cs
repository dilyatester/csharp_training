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

        public GroupHelper Modify(int index, GroupData newData)
        {
            manager.Navigator.GoToGroupPage();

            //Если  пользователь пытается удалять первый элемент, а его нет, то мы создадим его
            if ((index == 1) && (!IsExist(index)))
            {
                GroupData group = new GroupData("AutoCreated");
                group.Header = "AutoCreated";
                group.Footer = "AutoCreated";

                Create(group);
            }

            Assert.IsTrue(IsExist(index));
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

            //Если  пользователь пытается удалять первый элемент, а его нет, то мы создадим его
            if ((index == 1) && (!IsExist(index)))
            {
                GroupData group = new GroupData("AutoCreated");
                group.Header = "AutoCreated";
                group.Footer = "AutoCreated";

                Create(group);
            }

            Assert.IsTrue(IsExist(index));
            SelectGroup(index);
            RemoveGroup();
            manager.Navigator.GoToGroupPage();
            

            return this;
        }

        public bool IsExist(int index)
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]"));
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitNewGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
