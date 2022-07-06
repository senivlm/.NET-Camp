using System.Collections.Generic;

namespace Homework12
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
