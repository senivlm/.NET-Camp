using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    class Dish
    {
        private Dictionary<string, double> ingredients;

        public Dish()
        {
            ingredients = new();
        }

        public Dish(Dictionary<string, double> ingredients) : this()
        {
            this.ingredients = ingredients;
        }

        public double this[string key]
        {
            get
            {
                return ingredients[key];
            }
        }

        public int NumberOfIngredients { get { return ingredients.Count; } }

        public IEnumerable<string> Keys { get { return ingredients.Keys; } }

        public Dictionary<string, double> Ingredients { get => ingredients; }

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
            foreach (var item in ingredients)
            {
                result += $"ingradient: {item.Key}, grams: {item.Value}\n";
            }

            return result;
        }
    }
}
