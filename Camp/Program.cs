using System.Collections.Generic;
using System;

namespace Camp
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

        public static void WorkWithMeatClass()
        {
            Meat meat = new Meat("Grilled chicken", 120, 1, CategoryOfMeat.SecondSort, TypeOfMeat.Chicken);
            Console.WriteLine(meat);
            meat.ChangePrice(20);
            Console.WriteLine(meat);
            meat.ChangePrice(-120);
            Console.WriteLine(meat);
        }

        public static void WorkWithDairyProductsClass()
        {
            DairyProducts product = new DairyProducts("Milk", 25, 2, 7);
            Console.WriteLine(product);
            product.ChangePrice(50);
            Console.WriteLine(product);
        }

        public static void WorkWithStorageClass()
        {
            /*Storage storage = new Storage();
            storage.InputProducts();
            storage.AutoInitialization();
            storage.PrintAllInfoAboutProducts();
            storage.ChangePrice(20);
            storage.PrintAllInfoAboutProducts();*/

            Product[] products = new Product[4];
            products[0] = new Product("banana", 35, 1);
            products[1] = new Meat("sausage", 300, 2, CategoryOfMeat.HigherSort, TypeOfMeat.Mutton);
            products[2] = new Product("apple", 10, 5);
            products[3] = new Product("juice", 15, 0.5);
            Storage storage1 = new Storage(products);
            storage1.PrintAllInfoAboutProducts();

            Product p = storage1[2];
            Console.WriteLine(p);
        }

        public static void WorkWithMatrix()
        {
            Matrix m = new Matrix();
            m.InputSizeOfMatrix();
            m.VerticalSnakeInitialization();
            //m.RandomInitialization();
            //m.Input();
            m.OutputMatrix();
        }

        static void Main(string[] args)
        {
            //WorkWithProductClass();
            //WorkWithBuyClass();
            //WorkWithCheckClass();
            //WorkWithMeatClass();
            //WorkWithDairyProductsClass();
            WorkWithStorageClass();

            //WorkWithMatrix();
        }

        
    }
}
