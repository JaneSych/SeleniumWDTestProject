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
using SeleniumWDTestProject.page_objects;

namespace SeleniumWDTestProject
{
    public class Tests
    {
        public static IWebDriver driver;

        public static bool isElementPresent(By locator)
        {
            Thread.Sleep(100);
            return driver.FindElements(locator).Count != 0;
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Account/Login");

            LogInPage loginPage = new LogInPage(driver);
            MainPage mainPage = loginPage.logIn();

            Assert.AreEqual(driver.FindElement(By.TagName("h2")).Text, "Home page");
        }

        [Test]
        [TestCase("Monster Energy", "Beverages", "Exotic Liquids", "73.0000", "1", "1000", "1", false)]
        [TestCase("Adrenaline rush", "Beverages", "Mayumi's", "100.0000", "1", "500", "1", true)]
        [TestCase("Fitnes Shok", "Confections", "Specialty Biscuits, Ltd.", "89.0000", "1", "700", "1", false)]
        public void T1_CreateProduct(string Name, string Category, string Supplier, string UnitPrice, string Quantity, string UnitsInStock, string UnitsOnOrder, bool Discontinued)
        {
            MainPage mainPage = new MainPage(driver);
            ProductsListPage productsListPage = mainPage.goToProductsListPage();
            ProductPage productPage = productsListPage.createNewProduct();
            productPage.createProduct(Name, Category, Supplier, UnitPrice, Quantity, UnitsInStock, UnitsOnOrder, Discontinued);
  
            Assert.AreEqual(driver.Url, "http://localhost:5000/Product");
            Assert.IsTrue(isElementPresent(By.LinkText(Name)));
        }

        [Test]
        [TestCase("Monster Energy", "Beverages", "Exotic Liquids", "73.0000", "1", "1000", "1", false)]
        [TestCase("Adrenaline rush", "Beverages", "Mayumi's", "100.0000", "1", "500", "1", true)]
        [TestCase("Fitnes Shok", "Confections", "Specialty Biscuits, Ltd.", "89.0000", "1", "700", "1", false)]
        public void T2_ValuesChecking(string Name, string Category, string Supplier, string UnitPrice, string Quantity, string UnitsInStock, string UnitsOnOrder, bool Discontinued)
        {
            MainPage mainPage = new MainPage(driver);
            ProductsListPage productsListPage = mainPage.goToProductsListPage();

            Assert.IsTrue(isElementPresent(By.LinkText(Name)));
            ProductPage productPage = productsListPage.goToProductPage(Name);

            Assert.AreEqual(Name, productPage.getProductName());
            Assert.AreEqual(Category, productPage.getProductCategory());
            Assert.AreEqual(Supplier, productPage.getProductSupplier());
            Assert.AreEqual(UnitPrice, productPage.getProductPrice());
            Assert.AreEqual(Quantity, productPage.getProductQuantity());
            Assert.AreEqual(UnitsInStock, productPage.getProductInStock());
            Assert.AreEqual(UnitsOnOrder, productPage.getProductOnOrder());
            Assert.AreEqual(Discontinued, productPage.getProductDiscontinuedState());
        }

        [Test]
        [TestCase("Monster Energy")]
        [TestCase("Adrenaline rush")]
        [TestCase("Fitnes Shok")]
        public void T3_DeleteProduct(string Name)
        {
            MainPage mainPage = new MainPage(driver);
            ProductsListPage productsListPage = mainPage.goToProductsListPage();

            Assert.IsTrue(isElementPresent(By.LinkText(Name)));
            productsListPage.deleteProduct(Name);
 
            Assert.IsFalse(isElementPresent(By.LinkText(Name)));
        }

        [TearDown]
        public void TearDown()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            Assert.AreEqual(driver.FindElement(By.TagName("h2")).Text, "Login");
            driver.Close();
        }
    }
}