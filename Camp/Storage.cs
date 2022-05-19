using System;

namespace Camp
{
    class Storage
    {
        private Product[] arrayOfProducts;

        public Product this[int index]
        {
            get => arrayOfProducts[index];
            set => arrayOfProducts[index] = value;
        }

        public Storage(params Product[] arr)
        {
            arrayOfProducts = new Product[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arrayOfProducts[i] = arr[i];
            }
        }

        public Storage() { }

        #region Methods

        public void InputProducts()
        {
            Console.Write("Enter number of products: ");
            int numberOfProducts = int.Parse(Console.ReadLine());
            arrayOfProducts = new Product[numberOfProducts];
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
                    arrayOfProducts[i] = new Meat(productName, price, weight, cOfMeat, tOfMeat);
                }
                else
                {
                    arrayOfProducts[i] = new Product(productName, price, weight);
                }
                
            }
        }

        public void AutoInitialization()
        {
            arrayOfProducts = new Product[5];
            arrayOfProducts[0] = new Product("banana", 35, 1);
            arrayOfProducts[1] = new Meat("sausage", 300, 2, CategoryOfMeat.HigherSort, TypeOfMeat.Mutton);
            arrayOfProducts[2] = new Product("apple", 10, 5);
            arrayOfProducts[3] = new Product("juice", 15, 0.5);
            arrayOfProducts[4] = new Meat("chicken", 100, 1, CategoryOfMeat.SecondSort, TypeOfMeat.Chicken);
        }

        public void PrintAllInfoAboutProducts()
        {
            foreach(var item in arrayOfProducts)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void PrintAllMeatProducts()
        {
            foreach (var item in arrayOfProducts)
            {
                if(item.GetType() == typeof(Meat))
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        public void ChangePrice(int percent)
        {
            for(int i = 0; i < arrayOfProducts.Length; i++)
            {
                arrayOfProducts[i].ChangePrice(percent);
            }
        }

        #endregion
    }
}
