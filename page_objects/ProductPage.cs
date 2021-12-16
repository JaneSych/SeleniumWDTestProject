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
    class ProductPage : AbstractPage
    {
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ProductName")]
        private IWebElement productName;

        [FindsBy(How = How.Id, Using = "CategoryId")]
        private IWebElement dropDownCat;
        public SelectElement productCategory
        {
            get { return new SelectElement(dropDownCat); }
        }

        [FindsBy(How = How.Id, Using = "SupplierId")]
        private IWebElement dropDownSup;
        public SelectElement productSupplier
        {
            get { return new SelectElement(dropDownSup); }
        }

        [FindsBy(How = How.Id, Using = "UnitPrice")]
        private IWebElement productPrice;

        [FindsBy(How = How.Id, Using = "QuantityPerUnit")]
        private IWebElement productQuantity;

        [FindsBy(How = How.Id, Using = "UnitsInStock")]
        private IWebElement productInStock;

        [FindsBy(How = How.Id, Using = "UnitsOnOrder")]
        private IWebElement productOnOrder;

        [FindsBy(How = How.Id, Using = "Discontinued")]
        private IWebElement productDiscontinued;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement submitBtn;

        public ProductsListPage createProduct(string name, string category, string supplier, string price, string quantity, string unitsInStock, string unitsOnOrder, bool discontinued)
        {
            productName.SendKeys(name);
            productCategory.SelectByText(category);
            productSupplier.SelectByText(supplier);
            productPrice.SendKeys(price);
            productQuantity.SendKeys(quantity);
            productInStock.SendKeys(unitsInStock);
            productOnOrder.SendKeys(unitsOnOrder);
            if (discontinued == true) { productDiscontinued.Click(); }

            submitBtn.Click();

            return new ProductsListPage(driver);
        }

     
        //___________________________GET___________________________
        public string getProductName()
        {
            return productName.GetAttribute("value");
        }

        public string getProductCategory()
        {
            return productCategory.SelectedOption.Text;
        }

        public string getProductSupplier()
        {
            return productSupplier.SelectedOption.Text;
        }

        public string getProductPrice()
        {
            return productPrice.GetAttribute("value");
        }

        public string getProductQuantity()
        {
            return productQuantity.GetAttribute("value");
        }

        public string getProductInStock()
        {
            return productInStock.GetAttribute("value");
        }

        public string getProductOnOrder()
        {
            return productOnOrder.GetAttribute("value");
        }

        public bool getProductDiscontinuedState()
        {
            return driver.FindElements(By.XPath("//input[@id='Discontinued' and @checked = 'checked']")).Count != 0;
        }
    }
}
