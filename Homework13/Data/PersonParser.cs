using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13.Data
{
    internal static class PersonParser
    {
        public static Person Parse(string line)
        {
            Random random = new Random();
            string[] atributes = line.Split(' ');
            return new Person(
                atributes[0],
                atributes[1],
                int.Parse(atributes[2]),
                double.Parse(atributes[3]),
                int.Parse(atributes[4])
                );
        }
    }
}
