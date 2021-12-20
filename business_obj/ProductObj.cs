using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWDTestProject
{
    class ProductObj
    {
        private string productName;
        private string productCategory;
        private string productSupplier;
        private string productPrice;
        private string productQuantity;
        private string productInStock;
        private string productOnOrder;
        private bool productDiscontinued;

        public ProductObj(string name, string category, string supplier, string price, string quantity, string unitsInStock, string unitsOnOrder, bool discontinued)
        {
            this.productName = name;
            this.productCategory = category;
            this.productSupplier = supplier;
            this.productPrice = price;
            this.productQuantity = quantity;
            this.productInStock = unitsInStock;
            this.productOnOrder = unitsOnOrder;
            this.productDiscontinued = discontinued;
        }

        //___________________________GET___________________________
        public string getProductName()
        {
            return productName;
        }

        public string getProductCategory()
        {
            return productCategory;
        }

        public string getProductSupplier()
        {
            return productSupplier;
        }

        public string getProductPrice()
        {
            return productPrice;
        }

        public string getProductQuantity()
        {
            return productQuantity;
        }

        public string getProductInStock()
        {
            return productInStock;
        }

        public string getProductOnOrder()
        {
            return productOnOrder;
        }

        public bool getProductDiscontinuedState()
        {
            return productDiscontinued;
        }

        //___________________________SET___________________________
        public void setProductName(string name)
        {
            this.productName = name;
        }

        public void setProductCategory(string category)
        {
            this.productCategory = category;
        }

        public void setProductSupplier(string supplier)
        {
            this.productSupplier = supplier;
        }

        public void setProductPrice(string price)
        {
            this.productPrice = price;
        }

        public void setProductQuantity(string quantity)
        {
            this.productQuantity = quantity;
        }

        public void setProductInStock(string unitsInStock)
        {
            this.productInStock = unitsInStock;
        }

        public void setProductOnOrder(string unitsOnOrder)
        {
            this.productOnOrder = unitsOnOrder;
        }

        public void setProductDiscontinuedState(bool discontinued)
        {
            this.productDiscontinued = discontinued;
        }

    }
}
