using System;
using System.Collections.Generic;
using System.IO;

namespace Homework6
{
    class Program
    {//не знайшла результуючого файлу.
        static void Main(string[] args)
        {
            try
            {
                ElectricCompany electricCompany = new ElectricCompany("electricity.txt");
                //ім'я файлу краще передавати як параметр
                electricCompany.WriteReportToFile();
                electricCompany.WriteReportForCustomerToFile(20);
                Console.WriteLine("Client with the largest debt: " + electricCompany.ClientWithLargestDebt());
                Console.WriteLine("Apartment when electricity was not used: " + electricCompany.ApartmentWhenElectricityNotUsed());
                Console.WriteLine("Days since last checking electric meter:\n" + electricCompany.DaysSinceLastChecking());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
