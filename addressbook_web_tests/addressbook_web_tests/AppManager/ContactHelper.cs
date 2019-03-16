using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            InitClientCreation();
            FillClientForm(contact);
            SubmitClientCreation();
            
            return this;
        }

        public ContactHelper Modify(int t,ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("maintable")));
            InitContactModification(t);
            FillClientForm(newData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        private ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private ContactHelper InitContactModification(int j)
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@alt='Edit']")));

            ICollection<IWebElement> pencils = driver.FindElements(By.XPath("//img[@alt='Edit']"));
            IWebElement[] selectPencils = new IWebElement[pencils.Count];
            pencils.CopyTo(selectPencils, 0);

            selectPencils[j].Click();
            return this;
        }

        internal ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("maintable")));
            SelectContact(v);
            RemoveContact();
            manager.Navigator.GoToHomePage();

            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact(int i)
        {
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait2.Until(ExpectedConditions.ElementToBeClickable(By.Name("selected[]")));

            ICollection<IWebElement> checkboxes = driver.FindElements(By.Name("selected[]"));
            IWebElement[] selectBoxes = new IWebElement[checkboxes.Count];
            checkboxes.CopyTo(selectBoxes, 0);

            selectBoxes[i].Click();
            return this;
        }

        public ContactHelper SubmitClientCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper FillClientForm(ContactData client)
        {
            Type(By.Name("firstname"),client.FirstName);
            Type(By.Name("middlename"),client.MiddleName);
            Type(By.Name("lastname"),client.LastName);
            Type(By.Name("nickname"),client.NickName);
            Type(By.Name("title"),client.Title);
            Type(By.Name("company"),client.Company);
            Type(By.Name("address"),client.Address);
            Type(By.Name("home"),client.Home);
            Type(By.Name("mobile"),client.Mobile);
            Type(By.Name("work"),client.Work);
            Type(By.Name("fax"),client.Fax);
            Type(By.Name("email"),client.Email);
            Type(By.Name("email2"),client.Email2);
            Type(By.Name("email3"),client.Email3);
            Type(By.Name("homepage"),client.Homepage);
            Type(By.Name("bday"),client.Bday);
            Type(By.Name("bmonth"),client.Bmonth);
            Type(By.Name("byear"),client.Byear);
            Type(By.Name("aday"),client.Aday);
            Type(By.Name("amonth"),client.Amonth);
            Type(By.Name("ayear"),client.Ayear);
            Type(By.Name("address2"),client.Address2);
            Type(By.Name("phone2"),client.Phone2);
            Type(By.Name("notes"),client.Notes);
            return this;
        }

        public ContactHelper InitClientCreation()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("add new")));
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public bool IsContactExists()
        {
            return IsTheHomePageIsOpened() && IsElementPresent(By.Name("selected[]"));
        }

        public bool IsTheHomePageIsOpened()
        {
            return IsElementPresent(By.Id("maintable"));
        }


        public void EnsureContactExists()
        {
            manager.Navigator.GoToHomePage();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("maintable")));
            if (!IsContactExists())
            {
                ContactData con = new ContactData("test", "test1", "test2");
                Create(con);
            };
        }

        public List<ContactData> GetContactList()
        {
            manager.Navigator.GoToHomePage();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("maintable")));

            List<ContactData> contacts = new List<ContactData>();
            
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            foreach (IWebElement element in elements)
            {
                ICollection<IWebElement> cellElements = element.FindElements(By.TagName("td"));
                IWebElement[] contactCells = new IWebElement[cellElements.Count];
                cellElements.CopyTo(contactCells, 0);
                
                contacts.Add(new ContactData(contactCells[2].Text, "", contactCells[1].Text));
            }

            return contacts;
        }
    }
}
