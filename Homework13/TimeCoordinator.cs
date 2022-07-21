using Homework13.Data;
using Homework13.FileOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13
{
    internal class TimeCoordinator
    {// Є тільки канва програми. повністю умова задачі не виконана.
        private int timeCounter = 3;

        public List<string> Cordinate(List<Cassa> casses, string path)
        {
            Random random = new Random();
            bool isProcessor = true;
            int counter = 0;
            int time = 0;
            PersonGenerator personGenerator = new PersonGenerator();
            List<Person> persons = personGenerator.Generate();
            List<string> result = new ();

            while (isProcessor)
            {
                time++;
                if(time % timeCounter == 0 && counter < persons.Count)
                {
                    casses[random.Next(0, casses.Count)].Enqueue(persons[counter++]);
                }
                int i = 1;
                foreach (var item in casses)
                {
                    if(!item.IsEmpty() && --item.Peek().TimeServise <= 0)
                    {// треба вказати, якою касою.
                        result.Add($"Cassa {i++}: {item.Dequeue()} has been observed");

                        Console.WriteLine(result[result.Count - 1]);
                    }
                }
            }           
            Thread.Sleep(1000);
            return result; 
        }
    }
}
