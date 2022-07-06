using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Homework12
{
   
    class Storage
    {
        public event RecyclingFileHandler WriteEvent;
        private List<Product> productList;
        //максимальний термін зберігання на складі 21 день
        private readonly int maxExpirationDay = 21;

        public Storage(List<Product> products)
        {
            productList = new();
            foreach (var item in products)
            {
                productList.Add(item);
            }
        }

        public Storage()
        {
            productList = new();
        }

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

        public void DowloadProductsFromFile(string pathName)
        {
            if (!File.Exists(pathName))
            {
                throw new FileNotFoundException();
            }
            using(StreamReader reader = new StreamReader(pathName))
            {
                while (!reader.EndOfStream)
                {
                    Parse(reader.ReadLine());
                }
            }
        }

        private void Parse(string line)
        {
            string[] items = line.Split(' ');
            if(items.Length == 3)
            {
                productList.Add(new Product(items[0], double.Parse(items[1]), double.Parse(items[2])));
            }
            else if(items.Length == 4)
            {
                if(int.Parse(items[3]) > maxExpirationDay)
                {
                    if (WriteEvent != null)
                    {
                        WriteEvent(new DairyProducts(items[0], double.Parse(items[1]),
                         double.Parse(items[2]), int.Parse(items[3])));
                    }    
                }
                else
                {
                    productList.Add(new DairyProducts(items[0], double.Parse(items[1]),
                     double.Parse(items[2]), int.Parse(items[3])));
                }
            }
            else if(items.Length == 5)
            {
                productList.Add(new Meat(items[0], double.Parse(items[1]), double.Parse(items[2]), 
                    (CategoryOfMeat)Enum.Parse(typeof(CategoryOfMeat), items[3]), (TypeOfMeat)Enum.Parse(typeof(TypeOfMeat), items[4])));
            }
            else
            {
                throw new ArgumentException($"Line \"{line}\" cannot be converted to any product");
            }
        }

        public void AddProduct(Product product)
        {
            if(product is DairyProducts)
            {
                DairyProducts dairyProduct = (DairyProducts)product;
                if(dairyProduct.ExpirationDate > maxExpirationDay)
                {
                    if (WriteEvent != null) WriteEvent(dairyProduct);
                }
                else
                {
                    productList.Add(dairyProduct);
                }
            }
            else
            {
                productList.Add(product);
            }
        }

        //task 12_1
        public List<Product> SearchByName(string name)
        {
            var result = new List<Product>();
            int length = name.Length;
            foreach (var product in productList)
            {
                if(length <= product.ProductName.Length)
                {
                    if(product.ProductName.Substring(0, length).ToLower() == name.ToLower())
                    {
                        result.Add(product);
                    }
                }
            }
            return result;
        }

        public List<Product> SearchByPrice(string price)
        {
            var result = new List<Product>();
            foreach (var product in productList)
            {
                if (double.Parse(price) >= product.Price)
                {
                    result.Add(product);
                }
            }
            return result;
        }

        public List<Product> SearchByCategory(string category)
        {
            var result = new List<Product>();
            switch (category.ToLower())
            {
                case "meat":
                    foreach (var product in productList)
                    {
                        if(product is Meat)
                        {
                            result.Add(product);
                        }
                    }
                    break;
                case "dairy product":
                    foreach (var product in productList)
                    {
                        if (product is DairyProducts)
                        {
                            result.Add(product);
                        }
                    }
                    break;
                default:
                    throw new ArgumentException();
            }
            return result;
        }

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

        public IEnumerable<Product> GetExceptProducts(Storage storage)
        {
            return this.productList.Except(storage.productList, new ProductComparer());
        }
        public IEnumerable<Product> GetIntersectProducts(Storage storage)
        {
            return this.productList.Intersect(storage.productList, new ProductComparer());
        }
        public IEnumerable<Product> GetUnionProducts(Storage storage)
        {
            return this.productList.Union(storage.productList, new ProductComparer());
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
