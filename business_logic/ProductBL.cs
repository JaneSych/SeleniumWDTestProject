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

        public void createNewProduct(ProductObj product)
        {
            ProductPage createProductPage = new ProductPage(driver);
            createProductPage.createProduct(product.productName, product.productCategory, product.productSupplier, product.productPrice, 
                product.productQuantity, product.productInStock, product.productOnOrder,  product.productDiscontinued);
        }

        public bool productCheck(ProductObj product)
        {
            ProductPage productPage = new ProductPage(driver);

            return ((product.productName == productPage.getProductName())
            || (product.productCategory == productPage.getProductCategory())
            || (product.productSupplier == productPage.getProductSupplier())
            || (product.productPrice == productPage.getProductPrice())
            || (product.productQuantity == productPage.getProductQuantity())
            || (product.productInStock == productPage.getProductInStock())
            || (product.productOnOrder == productPage.getProductOnOrder())
            || (product.productDiscontinued == productPage.getProductDiscontinuedState()));
        }

    }
}
