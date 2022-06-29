using System;
using System.Collections.Generic;

namespace Homework8_2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<WebSiteUser> webSiteUsers = new();
            try
            {
                WebSiteUserReader webSiteUserReader = new("../../../statistics.txt");
                webSiteUsers = webSiteUserReader.Users;
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Users:");
                foreach (var user in webSiteUsers)
                {
                    Console.WriteLine(user);
                }
            }
            Console.WriteLine("\nNumber of visits per week:");
            Dictionary<string, int> visitsPerWeek = WebSiteService.GetNumberOfVisitsPerWeek(webSiteUsers);
            foreach (var item in visitsPerWeek)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            Console.WriteLine("\nThe most popular days of week:");
            Dictionary<DayOfWeek, int> mostPopularDays = WebSiteService.MostPopularDaysOfWeek(webSiteUsers);
            foreach (var item in mostPopularDays)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine($"\nThe most popular day: {WebSiteService.MostPopularDayOfWeek(webSiteUsers)}");
        }
    }
}
