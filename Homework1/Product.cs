namespace Homework1
{
    class Product
    {
        #region Fields

        protected string productName;
        protected double price;
        protected double weight;

        #endregion

        #region Constructors

        public Product(string productName, double price, double weight)
        {
            ProductName = productName;
            Price = price;
            Weight = weight;
        }

        public Product() : this(null, 0, 0) { }

        #endregion

        #region Properties

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        public double Price
        {
            get { return price; }
            set
            {
                if (value > 0) price = value;
                else price = 0;
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value > 0) weight = value;
                else weight = 0;
            }
        }

        #endregion

        #region Methods

        public virtual void ChangePrice(double percent)
        {
            Price += Price * (percent / 100);
        }

        public override string ToString()
        {
            return string.Format("Product name: {0}, price: {1}, weight: {2}", productName, price, weight);
        }

        #endregion
    }
}
