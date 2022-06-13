using System;
using System.Collections.Generic;
using System.IO;

//вибачте, що не вклався в дедлайн, не міг зробити раніше
//друге завдання буде зроблено 6.06 до вечора
namespace Homework6
{
    class ElectricCompany
    {
        #region Fields

        private List<(uint, string, uint, uint, DateTime, DateTime, DateTime, uint)> customers;
        private uint numberOfApartments;
        private uint quarter;
        const uint pricePerKilowatt = 4;

        #endregion

        public ElectricCompany(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {// Краще працювати з класом, а не з кортежем. крім того розділяти інформацію про квартиру(номер, власника) та заміри.
                customers = new List<(uint, string, uint, uint, DateTime, DateTime, DateTime, uint)>();
                string line = reader.ReadLine();
                ParseToNumberOfApartmentsAndNumberOfQuarter(line);
                int i = 0;
                while (i < numberOfApartments)
                {
                    line = reader.ReadLine();
                    string[] items = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    customers.Add(Parse(line));
                    i++;
                }
            }
        }

        #region Methods

        private void ParseToNumberOfApartmentsAndNumberOfQuarter(string line)
        {
            string[] firstLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            uint numberOfApartments, quarter;
            string exception = "";
            if(!uint.TryParse(firstLine[0], out numberOfApartments))
            {
                exception = "Invalid number of apartments format";
            }
            if (!uint.TryParse(firstLine[1], out quarter))
            {
                exception = "Invalid quarter format";
            }
            
            if(exception.Length != 0)
            {
                throw new FormatException(exception);
            }
            this.numberOfApartments = numberOfApartments;
            if (quarter > 4)
            {
                exception = "Invalid quarter format";
            }
            else
            {
                this.quarter = quarter;
            }
            
        }

        private static (uint, string, uint, uint, DateTime, DateTime, DateTime, uint) Parse(string line)
        {
            string[] items = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string exception = "";
            uint apartmentNumber, inputIndicator, outputIndicator, price;
            DateTime firstMonth, secondMonth, thirdMonth;
            if (!uint.TryParse(items[0], out apartmentNumber))
            {
                exception += "Invalid apartment number format";
            }
            if(items[1] == "")
            {
                exception += "Invalid name format";
            }
            if (!uint.TryParse(items[2], out inputIndicator))
            {
                exception += "Invalid intput indicator format";
            }
            if (!uint.TryParse(items[3], out outputIndicator))
            {
                exception += "Invalid iutput indicator format";
            }
            if(!DateTime.TryParse(items[4], out firstMonth))
            {
                exception += "Invalid date format";
            }
            if (!DateTime.TryParse(items[5], out secondMonth))
            {
                exception += "Invalid date format";
            }
            if (!DateTime.TryParse(items[6], out thirdMonth))
            {
                exception += "Invalid date format";
            }
            if(exception.Length != 0)
            {
                throw new FormatException(exception);
            }
            if(outputIndicator < inputIndicator)
            {
                throw new Exception("Output indicator can not be less than input indicator");
            }
            else
            {
                price = (outputIndicator - inputIndicator) * pricePerKilowatt;
            }
            return (apartmentNumber, items[1], inputIndicator, outputIndicator, firstMonth, secondMonth, thirdMonth, price);
        }

        private string[] MonthsName()
        {
            string[] months = new string[3];
            switch (quarter)
            {
                case 1: months[0] = "Січень";
                    months[1] = "Лютий";
                    months[2] = "Березень";
                    break;
                case 2:
                    months[0] = "Квітень";
                    months[1] = "Травень";
                    months[2] = "Червень";
                    break;
                case 3:
                    months[0] = "Липень";
                    months[1] = "Серпень";
                    months[2] = "Вересень";
                    break;
                case 4:
                    months[0] = "Жовтень";
                    months[1] = "Листопад";
                    months[2] = "Грудень";
                    break;
            }

            return months;
        } 

        public void WriteReportToFile()
        {
            using(StreamWriter writer = new StreamWriter("report.txt", false))
            {
                writer.WriteLine(this.ToString());
            }
        }

        public void WriteReportForCustomerToFile(uint numberOfApartment)
        {
            foreach (var item in customers)
            {
                if(item.Item1 == numberOfApartment)
                {
                    using (StreamWriter writer = new StreamWriter($"report(apartment №{numberOfApartment}).txt", false))
                    {
                        string[] months = MonthsName();
                        string title = $"Квартира\tПрiзвище\t{months[0]}\t\t{months[1]}\t\t{months[2]}\tВитрати";
                        writer.WriteLine(title);
                        writer.WriteLine($"{item.Item1}\t\t{item.Item2}\t{item.Item5.ToShortDateString()}\t{item.Item6.ToShortDateString()}\t{item.Item7.ToShortDateString()}\t{item.Item8}");
                    }
                }
            }
        }

        public string ClientWithLargestDebt()
        {
            uint largestDept = 0;
            string customerName = "there are no clients with debts";
            foreach (var item in customers)
            {
                if(largestDept < item.Item8)
                {
                    largestDept = item.Item8;
                    customerName = item.Item2;
                }
            }
            return customerName;
        }

        public uint ApartmentWhenElectricityNotUsed()
        {
            uint numberOfApartment = default;
            foreach (var item in customers)
            {
                if(item.Item8 == 0)
                {
                    numberOfApartment = item.Item1;
                }
            }
            return numberOfApartment;
        }

        public string DaysSinceLastChecking()
        {
            string period = "";
            DateTime today = DateTime.Now;
            TimeSpan interval;
            foreach (var item in customers)
            {
                interval = today - item.Item7;
                period += $"{item.Item2}: {interval.Days}\n";
            }
            return period;
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
            string[] months = MonthsName();
            string title = $"Квартира\tПрiзвище\t{months[0]}\t\t{months[1]}\t\t{months[2]}\tВитрати";
            string line = "";
            foreach (var item in customers)
            {
                line += $"{item.Item1}\t\t{item.Item2}\t{item.Item5.ToShortDateString()}\t{item.Item6.ToShortDateString()}\t{item.Item7.ToShortDateString()}\t{item.Item8}\n";
            }
            return $"{title}\n{line}";
            
        }

        #endregion
    }

}
