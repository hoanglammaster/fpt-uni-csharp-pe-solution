using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q1
{
    public class Product
    {
        int productId;
        double price;

        public Product()
        {
        }

        public Product(int productId, double price)
        {
            this.productId = productId;
            this.price = price;
        }

        public int ProductID
        {
            set
            {
                productId = value;
            }
            get
            {
                return productId;
            }
        }
        public double Price
        {
            set
            {
                price = value;
            }
            get
            {
                return price;
            }
        }

        public override string ToString()
        {
            return $"Product: {this.productId} - price: {this.price}";
        }
    }
}
