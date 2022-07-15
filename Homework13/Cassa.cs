using Homework13.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13
{
    internal class Cassa
    {
        private double coordinate;
        PriorityQueue<Person, string> queuePersons;
        public Cassa()
        {
            queuePersons = new();
            coordinate = 0;
        }

        public Cassa(int coordinate)
        {
            queuePersons = new();
            this.coordinate = coordinate;
        }

        public void Enqueue(Person person)
        {
            queuePersons.Enqueue(person, person.Status);
        }

        public Person Dequeue()
        {
            return queuePersons.Dequeue();
        }

        public Person Peek()
        {
            return queuePersons.Peek();
        }

        public bool IsEmpty()
        {
            return queuePersons.Count == 0;
        }


    }
}
