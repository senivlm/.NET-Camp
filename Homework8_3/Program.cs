using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Homework8_3
{
    class Program
    {
        public static void OperationsWithList()
        {
            List<Product> productList = new();
            //List<Product> productList = new();
            productList.Add(new Product("banana", 35, 1));
            productList.Add(new Meat("sausage", 300, 2, CategoryOfMeat.HigherSort, TypeOfMeat.Mutton));
            productList.Add(new Product("juice", 15, 0.5));
            productList.Add(new Meat("chicken", 100, 1, CategoryOfMeat.SecondSort, TypeOfMeat.Chicken));
            //Storage storage = new Storage(productList);

            List<Product> productList1 = new();
            productList1.Add(new Product("banana", 35, 1));
            productList1.Add(new Meat("sausage", 300, 2, CategoryOfMeat.HigherSort, TypeOfMeat.Mutton));

            //var unionProducts = productList.Union(productList1, new ProductComparer());
            //var unionProducts = productList.Intersect(productList1, new ProductComparer());
            var unionProducts = productList.Except(productList1, new ProductComparer());
            foreach (var item in unionProducts)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            List<Product> productList = new();
            productList.Add(new Product("banana", 35, 1));
            productList.Add(new Meat("sausage", 300, 2, CategoryOfMeat.HigherSort, TypeOfMeat.Mutton));
            productList.Add(new Product("juice", 15, 0.5));
            productList.Add(new Meat("chicken", 100, 1, CategoryOfMeat.SecondSort, TypeOfMeat.Chicken));
            Storage storage = new Storage(productList);

            List<Product> productList1 = new();
            productList1.Add(new Product("banana", 35, 1));
            productList1.Add(new Meat("sausage", 300, 2, CategoryOfMeat.HigherSort, TypeOfMeat.Mutton));
            productList1.Add(new Product("chocolate", 40, 3));
            Storage storage1 = new Storage(productList1);

            Console.WriteLine("Storage №1:\n" + storage);
            Console.WriteLine("Storage №2:\n" + storage1);
            var exceptProducts = productList.Except(productList1, new ProductComparer());
            var intersectProducts = productList.Intersect(productList1, new ProductComparer());
            var unionProducts = productList.Union(productList1, new ProductComparer());
            
            Console.WriteLine("Products which are in the first storage and aren`t in the second storage:");
            foreach (var item in exceptProducts)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nIntersect products:");
            foreach (var item in intersectProducts)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nJoint list of products, which are in the first and second storeges (without repetition):");
            foreach (var item in unionProducts)
            {
                Console.WriteLine(item);
            }
        }
    }
}
