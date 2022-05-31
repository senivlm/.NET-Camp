namespace Homework2
{
    class DairyProducts : Product
    {
        private int expirationDate;
        public int ExpirationDate
        {
            get { return expirationDate; }
            private set
            {
                if (value < 0) expirationDate = 0;
                else expirationDate = value;
            }
        }

        #region Constructors

        public DairyProducts(string productName, double price, double weight, int expirationDate)
            : base(productName, price, weight)
        {
            this.ExpirationDate = expirationDate;
        }

        public DairyProducts() : this(null, 0, 0, 0) { }

        #endregion

        #region Methods

        public override void ChangePrice(double percent)
        {
            if (percent >= 0) this.Price = Price + Price * (percent / 100) + expirationDate * 0.1;
            else this.Price = Price + Price * (percent / 100) - expirationDate * 0.1;
        }

        public override string ToString()
        {
            return base.ToString() + $", expitation date: {expirationDate}";
        }

        #endregion
    }
}
