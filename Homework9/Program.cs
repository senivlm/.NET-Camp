using System;
using System.Collections.Generic;
using System.IO;

namespace Homework9
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Currency, double> cRate = new();
            try
            {
                CurrencyRate currencyRate = new CurrencyRate("../../../Course.txt");
                cRate = currencyRate.GetCurrency();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Currency rate");
            foreach (var item in cRate)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }

            Dictionary<string, double> dicPriceList = new();
            try
            {
                PriceListReader priceListReader = new PriceListReader("../../../Prices.txt");
                dicPriceList = priceListReader.GetPriceList();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Price list: ");
            foreach (var item in dicPriceList)
            {
                Console.WriteLine($"Product: {item.Key}, price: {item.Value}");
            }
            PriceList priceList = new PriceList(dicPriceList);

            List<Dish> dishes = new();
            try
            {
                MenuReader menuReader = new MenuReader("../../../Menu.txt");
                dishes = menuReader.GetMenu();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nPrice for each dish:");
            foreach (var dish in dishes)
            {
                if (MenuService.TryGetDishPrice(dish, priceList, out double dishPrice))
                {
                    Console.WriteLine("Dish price: " + dishPrice);
                }
                else
                {
                    Console.WriteLine("It`s impossible to calculate price of dish!!!");
                }
            }

            Menu menu = new Menu(dishes);
            Console.WriteLine(menu);
            if (MenuService.TryGetGeneralPrice(menu, priceList, out double price))
            {
                Console.WriteLine("\nMenu price: " + price + " UAH");
                foreach (var item in cRate)
                {
                    Console.WriteLine($"Menu price in {item.Key}: {string.Format("{0:f2}", (price / item.Value))}");
                }
            }
            else
            {
                Console.WriteLine("Calculating price of menu is not possible");
            }

            Console.WriteLine("\nTotal amount of each product (in grams):");
            Dictionary<string, double> eachProductGrams = MenuService.GetEachProductGeneralGrams(menu, priceList);
            foreach (var item in eachProductGrams)
            {
                Console.WriteLine($"Product: {item.Key}, gramm: {item.Value}");
            }

            Console.Write("\nSelect a currency to calculate the total value of each product\n" +
                "1 - euro\n2 - dollar\nAny other key - UAH\nMake your choice -> ");
            string choice = Console.ReadLine();
            double rate;
            switch (choice)
            {
                case "1":
                    rate = cRate[Currency.Euro];
                    break;
                case "2":
                    rate = cRate[Currency.Dollar];
                    break;
                default:
                    rate = 1;
                    break;
            }
            Dictionary<string, double> eachProductPrice = MenuService.GetEachProductPrice(eachProductGrams, priceList, rate);
            foreach (var item in eachProductPrice)
            {
                Console.WriteLine($"Product: {item.Key}, general price: {string.Format("{0:f2}", (item.Value))}");
            }

            using (StreamWriter writer = new StreamWriter("../../../Result.txt"))
            {
                writer.WriteLine("Total amount of each product (in grams):");
                foreach (var item in eachProductGrams)
                {
                    writer.WriteLine($"Product: {item.Key}, gramm: {item.Value}");
                }
                writer.WriteLine("\nTotal price of each product:");
                foreach (var item in eachProductPrice)
                {
                    writer.WriteLine($"Product: {item.Key}, general price: {string.Format("{0:f2}", (item.Value))}");
                }
            }
        }
    }
}
