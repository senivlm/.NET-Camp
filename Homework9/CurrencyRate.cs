using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    class CurrencyRate
    {
        //private Currency currency;
        private StreamReader reader;
        public CurrencyRate(string fileName)
        {
            
            if (File.Exists(fileName))
            {
                reader = new(fileName);
            }
            else
            {
                throw new FileNotFoundException($"File \"{fileName}\" is not found");
            }
        }
        public Dictionary<Currency, double> GetCurrency()
        {
            Dictionary<Currency, double> currencyRate = new();
            while (!reader.EndOfStream)
            {
                string[] items = reader.ReadLine().Split(' ');
                if(Enum.TryParse(items[0], out Currency currency) && Double.TryParse(items[1], out double rate)) 
                {
                    currencyRate.Add(currency, rate);
                }
            }
            return currencyRate;
        }
    }
}
