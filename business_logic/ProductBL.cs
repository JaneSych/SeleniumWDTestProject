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

namespace SeleniumWDTestProject
{ 
    class ProductBL : AbstractPage
    {
        public ProductBL (IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void CreateNewProduct(ProductObj product)
        {
            ProductPage createNewProductPage = new ProductPage(driver);
            createNewProductPage.createProduct(
                product.getProductName(),
                product.getProductCategory(), 
                product.getProductSupplier(), 
                product.getProductPrice(),
                product.getProductQuantity(),
                product.getProductInStock(),
                product.getProductOnOrder(),
                product.getProductDiscontinuedState());
        }
    }
}
