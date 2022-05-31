using System;
using System.Collections.Generic;

namespace Homework1
{
    class Program
    {
        public static void WorkWithProductClass()
        {
            var product = new Product();
            var product1 = new Product("myProduct", 4, 2);
            Console.WriteLine(product);
            Console.WriteLine(product1);
        }

        public static void WorkWithBuyClass()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("Meat", 4, 2));
            products.Add(new Product("Milk", 10, 5));
            products.Add(new Product("Cheese", 3, 20));
            var buy = new Buy(products);
            Console.WriteLine(buy);

            buy.AddProduct(new Product("Sugar", 1, 27));
            Console.WriteLine();
            Console.WriteLine(buy);

        }

        public static void WorkWithCheckClass()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("Meat", 4, 2));
            products.Add(new Product("Milk", 10, 5));
            products.Add(new Product("Cheese", 3, 20));
            var buy = new Buy(products);
            Product product = new Product("Bread", 20, 0.5);
            Check.OutputInfoAboutBuy(buy);
            Check.OutputInfoAboutProduct(product);
        }



        static void Main(string[] args)
        {
            //WorkWithProductClass();
            //WorkWithBuyClass();
            WorkWithCheckClass();
        }
    }
}
