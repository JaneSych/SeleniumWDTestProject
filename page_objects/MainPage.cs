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
    class MainPage : AbstractPage
    {
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div/a[@href = \"/Product\"]")]
        private IWebElement products;

        public ProductsListPage goToProductsListPage()
        {
            products.Click();

            return new ProductsListPage(driver);
        }
    }
}
