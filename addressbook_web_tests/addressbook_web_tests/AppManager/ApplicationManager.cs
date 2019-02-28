using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public ApplicationManager ()
        {
        loginHelper = new LoginHelper(this);
        navigationHelper = new NavigationHelper(this, baseURL);
        groupHelper = new GroupHelper(this);
        contactHelper = new ContactHelper(this);


            driver = new FirefoxDriver();
            baseURL = "http://10.0.2.2/addressbook/index.php";
            //verificationErrors = new StringBuilder();
            //loginHelper = new LoginHelper(driver);
            //navigationHelper = new NavigationHelper(driver, baseURL);
            //groupHelper = new GroupHelper(driver);
            //contactHelper = new ContactHelper(driver);
        }


        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public void Stop ()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }
    }
}
