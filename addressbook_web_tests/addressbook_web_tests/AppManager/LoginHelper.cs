﻿using System;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager):base(manager)
        {
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"),account.UserName);
            Type(By.Name("pass"),account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }
        
        public void Logout()
        {
            if (IsLoggedIn())
            {
            driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() 
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text == "(" + account.UserName + ")";
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }
    }
}
