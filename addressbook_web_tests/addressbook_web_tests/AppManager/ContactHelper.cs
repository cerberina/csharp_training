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

        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            OpenContactDetailInformation(contact.Id);
            SelectGroupToRemoveFrom(group.Id);
            SelectContact(contact.Id);

            CommitRemovingContactFromGroup();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void CommitRemovingContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void SelectGroupToRemoveFrom(string groupId)
        {
            driver.FindElement(By.XPath("//a[@href=\"./index.php?group=" + groupId + "\"]")).Click();
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);

            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);

        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string groupName)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(groupName);
        }

        private void ClearGroupFilter()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(By.Name("group"))));
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string address_secondary = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            return new ContactData(firstName, middleName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Title = title,
                Company = company,
                NickName = nickname,
                Homepage = homepage,
                Address2 = address_secondary,
                Notes = notes,
                Phone2 = phone2,
                Fax = fax
            };
        }

        public ContactData GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            OpenContactDetailInformation(index);
            string allDetailedInformation = driver.FindElement(By.Id("content")).Text;
            return new ContactData("", "", "")
            {
                AllDetailedInformation = allDetailedInformation,
            };
        }

        public ContactHelper OpenContactDetailInformation(int index)
        {
            manager.Navigator.GoToHomePage();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@alt='Details']")));

            ICollection<IWebElement> humanIcon = driver.FindElements(By.XPath("//img[@alt='Details']"));
            IWebElement[] selectHuman = new IWebElement[humanIcon.Count];
            humanIcon.CopyTo(selectHuman, 0);

            selectHuman[index].Click();
            return this;
        }

        public ContactHelper OpenContactDetailInformation(string id)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@alt='Details']")));

            driver.FindElement(By.XPath("//a[@href=\"view.php?id=" + id + "\"]")).Click();
            return this;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;

            return new ContactData(firstName, "", lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails,
            };
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


        public ContactHelper Modify(ContactData contact, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("maintable")));
            InitContactModification(contact.Id);
            FillClientForm(newData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        private ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
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

        private ContactHelper InitContactModification(string id)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@alt='Edit']")));

            driver.FindElement(By.XPath("//a[@href=\"edit.php?id=" + id + "\"]")).Click();
            return this;
        }


        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("maintable")));
            SelectContact(v);
            RemoveContact();
            manager.Navigator.GoToHomePage();

            return this;
        }

        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("maintable")));
            SelectContact(contact.Id);
            RemoveContact();
            manager.Navigator.GoToHomePage();

            return this;
        }


        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
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

        public ContactHelper SelectContact(string id)
        {
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait2.Until(ExpectedConditions.ElementToBeClickable(By.Name("selected[]")));

            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }

        public ContactHelper SubmitClientCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
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
            Type(By.Name("home"),client.HomePhone);
            Type(By.Name("mobile"),client.MobilePhone);
            Type(By.Name("work"),client.WorkPhone);
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

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            manager.Navigator.GoToHomePage();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("maintable")));

            if (contactCache ==null)
            {
                contactCache = new List<ContactData>();

                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    ICollection<IWebElement> cellElements = element.FindElements(By.TagName("td"));
                    IWebElement[] contactCells = new IWebElement[cellElements.Count];
                    cellElements.CopyTo(contactCells, 0);

                    contactCache.Add(new ContactData(contactCells[2].Text, "", contactCells[1].Text));
                }
            }

            return new List<ContactData>(contactCache);
        }
    }
}
