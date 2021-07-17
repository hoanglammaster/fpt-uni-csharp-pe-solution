using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q1
{
    public delegate void Notify(Product p);
    class Order
    {
        public event Notify OnProductInforChange;
        private string id;
        private DateTime date;
        private Dictionary<Product, int> product;

        public Order()
        {
        }

        public Order(string id, DateTime date)
        {
            this.id = id;
            this.date = date;
            this.product = new Dictionary<Product, int>();
        }

        public Order(string id, DateTime date, Dictionary<Product, int> product) : this(id, date)
        {
            this.product = product;
        }

        public void AddProduct(Product p, int quantity)
        {
            bool contain = false;
            if (product == null)
            {
                product = new Dictionary<Product, int>();
            }
            for(int i = 0; i < product.Count; i++)
            {
                if(product.ElementAt(i).Key.ProductID == p.ProductID)
                {
                    contain = true;
                    product[product.ElementAt(i).Key] = product.ElementAt(i).Value + quantity;
                    break;
                }
            }
           
            if(contain == false)
            {
                product.Add(p, quantity);
            }
            if (OnProductInforChange != null)
            {
                OnProductInforChange(p);
            }
        }
        public void Display()
        {
            double total = 0;
            Console.WriteLine($"Order's info: Code: {id} - Date {date}");
            Console.WriteLine("List of Product:");
            for(int i = 0; i < product.Count; i++)
            {
                Console.WriteLine($"Product: {i} - price: {product.ElementAt(i).Key.Price} - Quantity: {product.ElementAt(i).Value}");
                total += product.ElementAt(i).Key.Price * product.ElementAt(i).Value;
            }
            Console.WriteLine($"Total amount of the Order: {total}");
            
        }
       
    }
}
