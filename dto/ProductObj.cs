using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWDTestProject
{
    class ProductObj
    {
        public string productName { get; }
        public string productCategory { get; }
        public string productSupplier { get; }
        public string productPrice { get; }
        public string productQuantity { get; }
        public string productInStock { get; }
        public string productOnOrder { get; }
        public bool productDiscontinued { get; }

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

     }
}
