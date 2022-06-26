using System;
using System.Collections.Generic;

namespace Homework8_3
{
    class Storage
    {
        private List<Product> productList;     

        

        public Storage(List<Product> products)
        {
            this.productList = products;
        }

        public Storage() : this(default) { }

        public Product this[int index]
        {
            get
            {
                if (index > 0 && index < productList.Count) return productList[index];
                else throw new IndexOutOfRangeException("Index out of range (productList)");
            }

            set 
            {
                productList[index] = value;
            } 
        }

        public List<Product> ProductList { get => productList; set => productList = value; }

        #region Methods

        public void InputProducts()
        {
            Console.Write("Enter number of products: ");
            int numberOfProducts = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfProducts; i++)
            {
                Console.WriteLine($"Input data about product №{i + 1}");
                int choice;
                do
                {
                    Console.WriteLine("Is it a meat product (enter '0') or not (enter '1')?");
                    choice = int.Parse(Console.ReadLine());
                }while (choice != 0 && choice != 1);
                Console.Write("Enter product name: ");
                string productName = Console.ReadLine();
                Console.Write("Enter price: ");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Enter weight: ");
                double weight = double.Parse(Console.ReadLine());
                if(choice == 0)
                {

                    Console.Write("Enter category of meeat: ");
                    string categoryOfMeat = Console.ReadLine();
                    CategoryOfMeat cOfMeat;
                    if (Enum.TryParse(typeof(CategoryOfMeat), categoryOfMeat, out object obj))
                    {
                        cOfMeat = (CategoryOfMeat)obj;
                    }
                    else
                    {
                        throw new Exception();
                    }

                    Console.Write("Enter type of meeat: ");
                    string typeOfMeat = Console.ReadLine();
                    TypeOfMeat tOfMeat;
                    if (Enum.TryParse(typeof(TypeOfMeat), typeOfMeat, out object obj1))
                    {
                        tOfMeat = (TypeOfMeat)obj1;
                    }
                    else
                    {
                        throw new Exception();
                    }
                    productList.Add(new Meat(productName, price, weight, cOfMeat, tOfMeat));
                }
                else
                {
                    productList.Add(new Product(productName, price, weight));
                }
                
            }
        }

        public void AutoInitialization()
        {
            productList.Add(new Product("banana", 35, 1));
            productList.Add(new Meat("sausage", 300, 2, CategoryOfMeat.HigherSort, TypeOfMeat.Mutton));
            productList.Add(new Product("apple", 10, 5));
            productList.Add(new Product("juice", 15, 0.5));
            productList.Add(new Meat("chicken", 100, 1, CategoryOfMeat.SecondSort, TypeOfMeat.Chicken));
        }

        public void ChangePrice(int percent)
        {
            for(int i = 0; i < productList.Count; i++)
            {
                productList[i].ChangePrice(percent);
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string result = "";
            foreach (var item in productList)
            {
                result += item + "\n";
            }
            return result;
        }

        #endregion
    }
}
