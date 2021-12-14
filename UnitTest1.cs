using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWDTestProject
{
    public class Tests
    {
        public static IWebDriver driver;

        public static bool isElementPresent(By locator)
        {
            Thread.Sleep(10);
            return driver.FindElements(locator).Count != 0;
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");

            string login = "user";
            string password = "user";

            driver.FindElement(By.Id("Name")).SendKeys(login);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            Assert.AreEqual(driver.FindElement(By.TagName("h2")).Text, "Home page");
        }

        [Test]
        [TestCase("Monster Energy", "Beverages", "Exotic Liquids", "73.0000", "1", "1000", "1", "non_checked")]
        [TestCase("Adrenaline rush", "Beverages", "Mayumi's", "100.0000", "1", "500", "1", "checked")]
        [TestCase("Fitnes Shok", "Confections", "Specialty Biscuits, Ltd.", "89.0000", "1", "700", "1", "non_checked")]
        public void T1_CreateProduct(string Name, string Category, string Supplier, string UnitPrice, string Quantity, string UnitsInStock, string UnitsOnOrder, string Discontinued)
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Product");
            driver.FindElement(By.LinkText("Create new")).Click();

            driver.FindElement(By.Id("ProductName")).SendKeys(Name);
            new SelectElement(driver.FindElement(By.Id("CategoryId"))).SelectByText(Category);
            new SelectElement(driver.FindElement(By.Id("SupplierId"))).SelectByText(Supplier);
            driver.FindElement(By.Id("UnitPrice")).SendKeys(UnitPrice);
            driver.FindElement(By.Id("QuantityPerUnit")).SendKeys(Quantity);
            driver.FindElement(By.Id("UnitsInStock")).SendKeys(UnitsInStock);
            driver.FindElement(By.Id("UnitsOnOrder")).SendKeys(UnitsOnOrder);
            if (Discontinued == "checked") { driver.FindElement(By.Id("Discontinued")).Click(); }

            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            Assert.AreEqual(driver.Url, "http://localhost:5000/Product");
            Assert.IsTrue(isElementPresent(By.LinkText("Monster Energy")));
        }

        [Test]
        [TestCase("Monster Energy", "Beverages", "Exotic Liquids", "73.0000", "1", "1000", "1", "non_checked")]
        [TestCase("Adrenaline rush", "Beverages", "Mayumi's", "100.0000", "1", "500", "1", "checked")]
        [TestCase("Fitnes Shok", "Confections", "Specialty Biscuits, Ltd.", "89.0000", "1", "700", "1", "non_checked")]
        public void T2_ValuesChecking(string Name, string Category, string Supplier, string UnitPrice, string Quantity, string UnitsInStock, string UnitsOnOrder, string Discontinued)
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Product");
            Assert.IsTrue(isElementPresent(By.LinkText(Name)));
            driver.FindElement(By.LinkText(Name)).Click();

            Assert.AreEqual(driver.FindElement(By.Id("ProductName")).GetAttribute("value"), Name);

            SelectElement selectedCategory = new SelectElement(driver.FindElement(By.Id("CategoryId")));
            Assert.AreEqual(selectedCategory.SelectedOption.Text, Category);

            SelectElement selectedSupplier = new SelectElement(driver.FindElement(By.Id("SupplierId")));
            Assert.AreEqual(selectedSupplier.SelectedOption.Text, Supplier);

            Assert.AreEqual(driver.FindElement(By.Id("UnitPrice")).GetAttribute("value"), UnitPrice);
            Assert.AreEqual(driver.FindElement(By.Id("QuantityPerUnit")).GetAttribute("value"), Quantity);
            Assert.AreEqual(driver.FindElement(By.Id("UnitsInStock")).GetAttribute("value"), UnitsInStock);
            Assert.AreEqual(driver.FindElement(By.Id("UnitsOnOrder")).GetAttribute("value"), UnitsOnOrder);

            if (Discontinued == "checked")
            {
                Assert.IsTrue(isElementPresent(By.XPath("//input[@id='Discontinued' and @checked = 'checked']")));
            }
            else Assert.IsFalse(isElementPresent(By.XPath("//input[@id='Discontinued' and @checked = 'checked']")));
        }

        [Test]
        [TestCase("Monster Energy")]
        [TestCase("Adrenaline rush")]
        [TestCase("Fitnes Shok")]
        public void T3_DeleteProduct(string Name)
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Product");
            Assert.IsTrue(isElementPresent(By.LinkText(Name)));
            driver.FindElement(By.XPath(string.Format("//td[a[contains(text(),'{0}')]]/following-sibling::td[a[contains(text(),'Remove')]]/a", Name))).Click();
            driver.SwitchTo().Alert().Accept();
            System.Console.WriteLine(isElementPresent(By.LinkText(Name)));
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