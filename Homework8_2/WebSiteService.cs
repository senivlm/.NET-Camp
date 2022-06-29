using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8_2
{
    class WebSiteService
    {
        public static Dictionary<string, int> GetNumberOfVisitsPerWeek(List<WebSiteUser> users)
        {
            Dictionary<string, int> visitsPerWeek = new();
            List<WebSiteUser> usersWithoutRepetition = new();
            users.ForEach((item) => { usersWithoutRepetition.Add(new WebSiteUser(item.Ip, item.Time, item.Day)); });
            for (int i = 0; i < usersWithoutRepetition.Count; i++)
            {
                visitsPerWeek.Add(usersWithoutRepetition[i].Ip, 1);
                for (int j = i + 1; j < usersWithoutRepetition.Count; j++)
                {
                    if (visitsPerWeek.ElementAt(i).Key == usersWithoutRepetition[j].Ip)
                    {
                        visitsPerWeek[visitsPerWeek.ElementAt(i).Key]++;
                        usersWithoutRepetition.RemoveAt(j);
                    }
                }
            }
            return visitsPerWeek;
        }

        public static Dictionary<DayOfWeek, int> MostPopularDaysOfWeek(List<WebSiteUser> users)
        {
            Dictionary<DayOfWeek, int> mostPopularDays = new();
            List<WebSiteUser> usersWithoutRepetition = new();
            users.ForEach((item) => { usersWithoutRepetition.Add(new WebSiteUser(item.Ip, item.Time, item.Day)); });
            for (int i = 0; i < usersWithoutRepetition.Count; i++)
            {
                mostPopularDays.Add(usersWithoutRepetition[i].Day, 1);
                for (int j = i + 1; j < usersWithoutRepetition.Count; j++)
                {
                    if (mostPopularDays.ElementAt(i).Key == usersWithoutRepetition[j].Day)
                    {
                        mostPopularDays[mostPopularDays.ElementAt(i).Key]++;
                        usersWithoutRepetition.RemoveAt(j);
                    }
                }
            }
            return mostPopularDays;
        }

        public static DayOfWeek MostPopularDayOfWeek(List<WebSiteUser> users)
        {
            Dictionary<DayOfWeek, int> mostPopularDays = MostPopularDaysOfWeek(users);
            var keyOfMaxValue = mostPopularDays.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            return keyOfMaxValue;
        }
    }
}
