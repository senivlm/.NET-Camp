using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class Pair
    {
        private int number;
        private int freq;

        public Pair(int number, int freq)
        {
            this.Number = number;
            this.Freq = freq;
        }



        public int Number { get => number; set => number = value; }
        public int Freq { get => freq; set => freq = value; }

        public override string ToString()
        {
            return $"number: {number}, amount: {freq}";
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            if(!(obj is Pair))
            {
                return false;
            }
            Pair pair = (Pair)obj;
            return (this.Number == pair.Number && this.Freq == pair.Freq);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
