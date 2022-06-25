using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    class Menu
    {
        private List<Dish> dishes;
       
        public Menu()
        {
            dishes = new();
        }

        public Menu(List<Dish> dishes) :this()
        {
            this.dishes = dishes;
        }

        public Dish this[int index]
        {
            get
            {
                return dishes[index];
            }
        }
        public int Length => dishes.Count;

        internal List<Dish> Dishes { get => dishes; }


        /*        public Dictionary<string, double> GetEachProductGram()
                {
                    Dictionary<string, double> priceForEachProduct = dicPriceList.ToDictionary(entry => entry.Key, entry => 0.0);
                }*/


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Length; i++)
            {
                result += $"Dish №{i + 1}:\n{dishes[i]}";
            }

            return result;
        }
    }
}
