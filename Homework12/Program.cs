using System;
using System.Collections.Generic;

namespace Homework12
{
    class Program
    {
        static void Main(string[] args)
        {
            //task 1
            Storage storage = new Storage();
            Writer writer = new();
            writer.ClearFile();
            storage.WriteEvent += writer.WriteToFile;
            storage.DowloadProductsFromFile("../../../Storage.txt");
            storage.AddProduct(new Product("cake", 52, 100));
            storage.AddProduct(new DairyProducts("yogurt", 15, 400, 30));
            storage.AddProduct(new DairyProducts("kefir", 16, 350, 5));

            Console.WriteLine("Storage:");
            foreach (var item in storage.ProductList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //task 2            
            while (true)
            {
                List<Product> result = new();
                Console.Write("Select the search\n1 - by name\n2 - by price\n" +
                    "by category: 3 (meat) 4 (dairy product)\nany key - exit\nYour choice -> ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("input product name -> ");
                        string productName = Console.ReadLine();
                        result = storage.SearchByName(productName);
                        break;
                    case "2":
                        Console.Write("input max price -> ");
                        string maxPrice = Console.ReadLine();
                        result = storage.SearchByPrice(maxPrice);
                        break;
                    case "3":
                        result = storage.SearchByCategory("meat");
                        break;
                    case "4":
                        result = storage.SearchByCategory("dairy product");
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
        }
    }
}
