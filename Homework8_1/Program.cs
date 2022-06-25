using System;
using System.Collections.Generic;

namespace Homework8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*DateTime date1 = new DateTime(2022, 04, 20);
            DateTime date2 = new DateTime(2022, 05, 20);
            DateTime date3 = new DateTime(2022, 06, 20);
            ApartmentReport apartment1 = new ApartmentReport(10, "Obramenko", 10, 20, date1, date2, date3, 100);
            ApartmentReport apartment2 = new ApartmentReport(10, "Petrov", 45, 79, date1, date2, date3, 250);
            List<ApartmentReport> apartments = apartment1 + apartment2;
            foreach (var item in apartments)
            {
                Console.WriteLine(item);
            }*/

            try
            {
                ElectricCompany electricCompany = new ElectricCompany("electricity.txt");
                electricCompany.WriteReportToFile("../../../report.txt");
                ElectricCompany electricCompany1 = new ElectricCompany("electricity1.txt");
                electricCompany1.WriteReportToFile("../../../report1.txt");

                List<ApartmentReport> apartmentReports = new();
                apartmentReports = electricCompany + electricCompany1;
                foreach (var item in apartmentReports)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("*****************************");
                apartmentReports.Clear();
                apartmentReports = electricCompany - electricCompany1;
                foreach (var item in apartmentReports)
                {
                    Console.WriteLine(item);
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
