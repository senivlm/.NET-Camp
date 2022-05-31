using System.Collections.Generic;

namespace Homework2
{//ddhfhgjfjfj
    class Buy
    {
        #region Field

        private List<Product> products;

        #endregion

        #region Constructors

        public Buy(List<Product> products)
        {
            this.products = products;
        }

        public Buy()
        {
            products = new List<Product>();
        }
        
        #endregion

        #region Methods

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public int Count()
        {
            return products.Count;
        }

        public double SummaryPrice()
        {
            double sumPrice = 0;
            foreach(var item in products)
            {
                sumPrice += item.Price;
            }
            return sumPrice;
        }

        public double SummaryWeight()
        {
            double sumWeight = 0;
            foreach (var item in products)
            {
                sumWeight += item.Weight;
            }
            return sumWeight;
        }

        public override string ToString()
        {
            string str = "";
            foreach(var item in products)
            {
                str += $"Product name: {item.ProductName}, price: {item.Price}, weight: {item.Weight}\n";
            }
            return str + $"Quantity of products: {this.Count()} + price of all product: {this.SummaryPrice()}, " +
                $"weight of all product: {this.SummaryWeight()}";
        }

        #endregion
    }
}
