using System;
using System.Collections.Generic;
using System.IO;

namespace Homework8_1
{
    enum Quarter { First = 1, Second, Third, Fourth }

    class ElectricCompany
    {
        #region Fields

        private List<ApartmentReport> customers;
        private uint numberOfApartments;
        private Quarter quarter;
        const uint pricePerKilowatt = 4;

        #endregion

        public ElectricCompany(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                customers = new List<ApartmentReport>();
                string line = reader.ReadLine();
                ParseToNumberOfApartmentsAndNumberOfQuarter(line);
                int i = 0;
                while (i < numberOfApartments)
                {
                    line = reader.ReadLine();
                    string[] items = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    AddCustomer(line);
                    i++;
                }
            }
        }

        #region Methods

        public static List<ApartmentReport> operator -(ElectricCompany obj1, ElectricCompany obj2)
        {
            List<ApartmentReport> unionApartments = new();
            int i = 0;
            foreach (var item1 in obj1.customers)
            {
                i = 0;
                foreach (var item2 in obj2.customers)
                {
                    if(item1.OwnerName == item2.OwnerName && item1.ApartmentNumber == item2.ApartmentNumber)
                    {
                        i++;
                    }
                }
                if (i == 0)
                {
                    unionApartments.Add(item1);
                }
            }
            return unionApartments;
        }

        public static List<ApartmentReport> operator +(ElectricCompany obj1, ElectricCompany obj2)
        {
            List<ApartmentReport> unionApartments = new();
            foreach (var item in obj1.customers)
            {
                unionApartments.Add(item);
            }
            foreach (var item in obj2.customers)
            {
                unionApartments.Add(item);
            }
            return unionApartments;
        }



        private void ParseToNumberOfApartmentsAndNumberOfQuarter(string line)
        {
            string[] firstLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            uint numberOfApartments = 0;
            int quarterNumber;
            string exception = "";
            if(!uint.TryParse(firstLine[0], out numberOfApartments))
            {
                exception += "Invalid number of apartments format";
            }
            if (!int.TryParse(firstLine[1], out quarterNumber))
            {
                exception += "Invalid quarter format";
            }

            if(exception.Length != 0)
            {
                throw new FormatException(exception);
            }
            this.numberOfApartments = numberOfApartments;
            if (Enum.IsDefined(typeof(Quarter), quarterNumber))
            {
                this.quarter = (Quarter)quarterNumber;
            }
            else
            {
                throw new IndexOutOfRangeException("No such quarter exists");
            }
        }

        private void AddCustomer(string line)
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
            customers.Add(new ApartmentReport(apartmentNumber, items[1], inputIndicator, outputIndicator, firstMonth, secondMonth, thirdMonth, price));
        }

        private string[] MonthsName()
        {
            string[] months = new string[3];
            switch (quarter)
            {
                case Quarter.First: months[0] = "Січень";
                    months[1] = "Лютий";
                    months[2] = "Березень";
                    break;
                case Quarter.Second:
                    months[0] = "Квітень";
                    months[1] = "Травень";
                    months[2] = "Червень";
                    break;
                case Quarter.Third:
                    months[0] = "Липень";
                    months[1] = "Серпень";
                    months[2] = "Вересень";
                    break;
                case Quarter.Fourth:
                    months[0] = "Жовтень";
                    months[1] = "Листопад";
                    months[2] = "Грудень";
                    break;
            }
            return months;
        } 

        public void WriteReportToFile(string fileName)
        {
            using(StreamWriter writer = new StreamWriter(fileName, false))
            {
                writer.WriteLine(this.ToString());
            }
        }

        public void WriteReportForCustomerToFile(uint numberOfApartment)
        {
            foreach (var item in customers)
            {
                if (item.ApartmentNumber == numberOfApartment)
                {
                    using (StreamWriter writer = new StreamWriter($"report(apartment №{numberOfApartment}).txt", false))
                    {
                        string[] months = MonthsName();
                        string title = $"Квартира\tПрiзвище\t{months[0]}\t\t{months[1]}\t\t{months[2]}\tВитрати";
                        writer.WriteLine(title);
                        writer.WriteLine($"{item.ApartmentNumber}\t\t{item.OwnerName}\t{item.FirstMonth.ToShortDateString()}" +
                            $"\t{item.SecondMonth.ToShortDateString()}\t{item.ThirdMonth.ToShortDateString()}\t{item.AmountOfPayment}");
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
                if (largestDept < item.AmountOfPayment)
                {
                    largestDept = item.AmountOfPayment;
                    customerName = item.OwnerName;
                }
            }
            return customerName;
        }

        public uint ApartmentWhenElectricityNotUsed()
        {
            uint numberOfApartment = default;
            foreach (var item in customers)
            {
                if (item.AmountOfPayment == 0)
                {
                    numberOfApartment = item.ApartmentNumber;
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
                interval = today - item.ThirdMonth;
                period += $"{item.OwnerName}: {interval.Days}\n";
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
                line += $"{item.ApartmentNumber}\t\t{item.OwnerName}\t{item.FirstMonth.ToShortDateString()}\t" +
                    $"{item.SecondMonth.ToShortDateString()}\t{item.ThirdMonth.ToShortDateString()}\t{item.AmountOfPayment}\n";
            }
            return $"{title}\n{line}";
            
        }

        #endregion
    }

}
