using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13.Data
{
    internal class Person
    {
        public Guid Id { get; }
        public string Status { get => status; }

        private string name;
        private int timeServise; 
        private int age;
        private double coordinate;
        private string status;

        public Person(string status, string name, int age, double coordinate, int timeServise)
        {
            Id = Guid.NewGuid();
            this.name = name;
            this.timeServise = timeServise;
            this.age = age;
            this.coordinate = coordinate;
            this.status = status;
        }

        public Person() : this("", "", default, default, default)
        {

        }

        public int TimeServise 
        { 
            get => timeServise;
            set
            {
                timeServise = value;
            }
        }

        public override string? ToString()
        {
            return $"[{status}] - {name} {age} {coordinate} {timeServise}";
        }
    }
}
