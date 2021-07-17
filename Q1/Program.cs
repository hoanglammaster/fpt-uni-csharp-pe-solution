using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q1
{
    class Program
    {
        public static void Notify(Product p)
        {
            Console.WriteLine($"Total amount of order change because the change of product: {p}");
            Console.WriteLine("-----------------");
        }
        static void Main(string[] args)
        {
            Product p = new Product(1,10.5);
            Order o = new Order("01", new DateTime(2021, 5, 1));
            o.AddProduct(p, 1);
            o.AddProduct(new Product(2, 20), 2);
            o.AddProduct(new Product(1, 10.5), 2);
            o.Display();
            o.OnProductInforChange += Notify;
            o.AddProduct(new Product(3, 20), 10);
            o.Display();
            Console.ReadLine();
        }
    }
}
