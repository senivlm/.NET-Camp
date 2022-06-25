using System;
using System.Collections.Generic;
using System.IO;

namespace Homework9
{
    class MenuReader
    {
        private StreamReader reader;
        private List<Dish> dishes;

        public MenuReader(string fileName)
        {
            if (File.Exists(fileName))
            {
                reader = new StreamReader(fileName);
                dishes = new();
            }
            else
            {
                throw new FileNotFoundException($"File \"{fileName}\" is not found");
            }
        }

        public List<Dish> GetMenu()
        {
            Dictionary<string, double> ingradients = new();
            List<Dish> dishes = new();
            bool isEmpty;
            string line;
            while (!reader.EndOfStream)
            {
                ingradients = new();
                isEmpty = false;
                reader.ReadLine();
                while (!isEmpty)
                {
                    line = reader.ReadLine();
                    if(line != "" && line != null)
                    {
                        string[] items = line.Split(' ');
                        ingradients.Add(items[0], Convert.ToDouble(items[1]));
                    }
                    else
                    {
                        isEmpty = true;
                    }
                }
                dishes.Add(new Dish(ingradients));  
            }
            return dishes;
        }
    }
}
