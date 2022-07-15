using Homework13.Data;
using Homework13.FileOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13
{
    internal class PersonGenerator
    {
        Random random = new Random();
        public List<Person> Generate()
        {
            Reader reader = new Reader();
            List<Person> result = new List<Person>();
            List<string> persons = reader.ReadExpresion();
            foreach (var item in persons)
            {
                result.Add(PersonParser.Parse(item));
            }

            return result;
        }

        public void WriteRandomGenerate(int randomMax)
        {
            Writer writer = new Writer();
            for (int i = 0; i < randomMax; i++)
            {
                writer.WritePerson(new Person(                    
                    $"Status{random.Next(1, 3)}",
                    $"Pasanger{Guid.NewGuid().ToString()[33..]}",
                    random.Next(0, randomMax),
                    Math.Round(random.NextDouble(), 2),
                    random.Next(1, 10)
                    ));
            }
        }
        
    }
}
