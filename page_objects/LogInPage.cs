using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;

namespace SeleniumWDTestProject.page_objects
{
    class LogInPage : AbstractPage
    {
       public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "Name")]
        private IWebElement loginInput;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement passwordInput;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement submitBtn;

        public MainPage logIn(string login, string password)
        {
            loginInput.SendKeys(login);
            passwordInput.SendKeys(password);
            submitBtn.Click();

            return new MainPage(driver);
        }
    }
}
