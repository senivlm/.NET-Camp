using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8_3
{
    class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            if(x.ProductName == y.ProductName && 
                x.Price == y.Price && x.Weight == y.Weight)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Product obj)
        {
            return obj.ProductName.GetHashCode();
        }
    }
}
