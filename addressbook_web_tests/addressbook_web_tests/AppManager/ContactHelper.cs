using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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

        public ContactHelper Modify(ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            if (! IsElementPresent(By.Name("selected[]")))
            {
                ContactData con = new ContactData("test","test1","test2");
                Create(con);
            }
            InitContactModification();
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

        private ContactHelper InitContactModification()
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@alt='Edit']")));
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        internal ContactHelper Remove()
        {
            manager.Navigator.GoToHomePage();
          
            SelectContact();

            RemoveContact();
            manager.Navigator.GoToHomePage();

            return this;
        }

        public ContactHelper RemoveContact()
        {
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@value='Delete']")));
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("maintable")));
            
            if (!IsElementPresent(By.Name("selected[]")))
            {
                ContactData con = new ContactData("test", "test1", "test2");
                Create(con);
            }
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait2.Until(ExpectedConditions.ElementToBeClickable(By.Name("selected[]")));
            driver.FindElement(By.Name("selected[]")).Click();
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
    }
}
