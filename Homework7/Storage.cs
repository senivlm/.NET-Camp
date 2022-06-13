using System;
using System.Collections.Generic;
using System.IO;

namespace Homework7
{
    class Storage
    {
        private List<Product> productsList;

        public Product this[int index]
        {
            get 
            {
                if(index < productsList.Count && index >= 0)
                {
                    return productsList[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index out of range");
                }
                
            }
            set
            {
                productsList[index] = value;
            }
            
        }

        public Storage(List<Product> products)
        {
            this.productsList = products;
        }

        public Storage() //:this(default)
        {
            productsList = new List<Product>();
        }

        #region Methods

        private void ReadProducts(string fileName)
        {
            string exceptions = "";
            double price = 0, weight = 0;
            TypeOfMeat typeOfMeat = TypeOfMeat.Mutton;
            CategoryOfMeat categoryOfMeat = CategoryOfMeat.HigherSort;
            ErrorLog log = new ErrorLog();
            using (StreamReader reader = new StreamReader(fileName))
            {
                bool isMeat = false;
                while (!reader.EndOfStream)
                {
                    isMeat = false;
                    exceptions = "";
                    string[] productInfo = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (productInfo.Length == 3 || productInfo.Length == 5)
                    {
                        productInfo[0] = productInfo[0].Substring(0, 1).ToUpper() + productInfo[0].Substring(1, productInfo[0].Length - 1).ToLower();
                        if (!double.TryParse(productInfo[1], out price))
                        {
                            exceptions += "Invalid price format\t" + DateTime.Now + "\n";
                        }
                        if(!double.TryParse(productInfo[2], out weight))
                        {
                            exceptions += "Invalid weight format\t" + DateTime.Now + "\n";
                        }
                        if(productInfo.Length == 5)
                        {
                            isMeat = true;
                            productInfo[3] = productInfo[3].Substring(0, 1).ToUpper() + productInfo[3].Substring(1, 5).ToLower()
                                + productInfo[3].Substring(6, 1).ToUpper() + productInfo[3].Substring(7, productInfo[3].Length - 7).ToLower();
                            productInfo[4] = productInfo[4].Substring(0, 1).ToUpper() + productInfo[4].Substring(1, productInfo[4].Length - 1).ToLower();
                            
                            if(!Enum.TryParse(productInfo[3], out categoryOfMeat))
                            {
                                exceptions += "Invalid categoty of meat format\t" + DateTime.Now + "\n";
                            }
                            if(!Enum.TryParse(productInfo[4], out typeOfMeat))
                            {
                                exceptions += "Invalid type of meat format\t" + DateTime.Now + "\n";
                            }
                        }
                    }
                    else
                    {
                        exceptions += "Incorrect number of data in line\t" + DateTime.Now + "\n";
                    }
                    if(exceptions.Length == 0)
                    {
                        if (isMeat)
                        {
                            productsList.Add(new Meat(productInfo[0], price, weight, categoryOfMeat, typeOfMeat));
                        }
                        else
                        {
                            productsList.Add(new Product(productInfo[0], price, weight));
                        }
                    }
                    else
                    {
                        log.WriteErrorToLog(exceptions);
                    }
                }
            }
        }

        public void ReadProductsFromFile(string fileName)
        {
            while (!File.Exists(fileName))
            {
                //I understand that using Console.ReadLine()
                //and Concole.WriteLine() in this method is a bad idea
                Console.WriteLine($"File \"{fileName}\" doesn`t exist! Please, enter a different file name:");
                fileName = Console.ReadLine();
            }
            ReadProducts(fileName);
        }

        public void AddProduct(Product product)
        {
            productsList.Add(product);
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
                } while (choice != 0 && choice != 1);
                Console.Write("Enter product name: ");
                string productName = Console.ReadLine();
                Console.Write("Enter price: ");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Enter weight: ");
                double weight = double.Parse(Console.ReadLine());
                if (choice == 0)
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
                    productsList.Add(new Meat(productName, price, weight, cOfMeat, tOfMeat));
                }
                else
                {
                    productsList.Add(new Product(productName, price, weight));
                }

            }
        }

        public void AutoInitialization()
        {
            productsList.Add(new Product("banana", 35, 1));
            productsList.Add(new Meat("sausage", 300, 2, CategoryOfMeat.HigherSort, TypeOfMeat.Mutton));
            productsList.Add(new Product("apple", 10, 5));
            productsList.Add(new Product("juice", 15, 0.5));
            productsList.Add(new Meat("chicken", 100, 1, CategoryOfMeat.SecondSort, TypeOfMeat.Chicken));
        }




        public void PrintAllInfoAboutProducts()
        {
            foreach(var item in productsList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void PrintAllMeatProducts()
        {
            foreach (var item in productsList)
            {
                if(item.GetType() == typeof(Meat))
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        public void ChangePrice(int percent)
        {
            for(int i = 0; i < productsList.Count; i++)
            {
                productsList[i].ChangePrice(percent);
            }
        }

        #endregion
    }
}
