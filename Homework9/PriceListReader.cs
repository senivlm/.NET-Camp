using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    class PriceListReader
    {
        private StreamReader reader;

        public PriceListReader(string fileName)
        {
            if (File.Exists(fileName))
            {
                reader = new StreamReader(fileName);
            }
            else
            {
                throw new FileNotFoundException($"File \"{fileName}\" is not found");
            }
        }

        public Dictionary<string, double> GetPriceList()
        {
            Dictionary<string, double> result = new();
            string exceptions = "";
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] items = line.Split(' ');
                if (items.Length < 2)
                {
                    //throw new ArgumentException($"String \"{line}\" has less then 2 items");
                    exceptions += $"String \"{line}\" has less then 2 items";
                }
                else
                {
                    double price = 0;
                    if (!double.TryParse(items[1], out price))
                    {
                        //throw new ArgumentException($"String \"{line}\" has invalid price format");
                        exceptions += $"String \"{line}\" has invalid price format";
                    }
                    else
                    {
                        result.Add(items[0], price);
                    }
                }
            }
            if(exceptions.Length != 0)
            {
                throw new ArgumentException(exceptions);
            }
            return result;
        }
    }
}
