using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    class PriceList
    {
        private Dictionary<string, double> productPrice;
        public PriceList()
        {
            productPrice = new();
        }
        public PriceList(Dictionary<string, double> productPrice) : this()
        {
            this.productPrice = productPrice;
        }

        public Dictionary<string, double> ProductPrice { get => productPrice; }

        public bool TryGetProductPrice(string productName, out double result)
        {            
            if(!productPrice.TryGetValue(productName, out result))
            {
                return false;
            }
            return true;
        }

    }
}
