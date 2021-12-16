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
    class ProductsListPage : AbstractPage
    {
        IWebElement product;
        public ProductsListPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Create new")]
        private IWebElement createBtn;

        public ProductPage createNewProduct()
        {
            createBtn.Click();

            return new ProductPage(driver);
        }

        public ProductPage goToProductPage(string name)
        {
            IWebElement product = driver.FindElement(By.LinkText(name)); 
            product.Click();

            return new ProductPage(driver);
        }

        public void deleteProduct(string name)
        {
            IWebElement removeLink = driver.FindElement(By.XPath(string.Format("//td[a[contains(text(),'{0}')]]/following-sibling::td[a[contains(text(),'Remove')]]/a", name)));
            removeLink.Click();
            driver.SwitchTo().Alert().Accept();
        }
    }
}
