namespace Homework8_3
{
    enum CategoryOfMeat { HigherSort, SecondSort }
    enum TypeOfMeat { Mutton, Veal, Pork, Chicken }

    class Meat : Product
    {
        #region Fields

        private CategoryOfMeat category;
        private TypeOfMeat type;

        #endregion

        #region Constructorrs

        public Meat(string productName, double price, double weight, CategoryOfMeat category, TypeOfMeat type)
            : base(productName, price, weight)
        {
            this.category = category;
            this.type = type;
        }

        public Meat() : this(null, 0, 0, default, default) { }

        #endregion

        #region Methods

        public override void ChangePrice(double percent)
        {
            switch (category)
            {
                case CategoryOfMeat.HigherSort:
                    if(percent >= 0) Price = (Price + Price * (percent / 100)) * 1.2;
                    else Price = (Price + Price * (percent / 100)) / 1.2;
                    break;
                case CategoryOfMeat.SecondSort:
                    if (percent >= 0) Price = (Price + Price * (percent / 100)) * 1.1;
                    else Price = (Price + Price * (percent / 100)) / 1.1;
                    break;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", category: {0}, type: {1}",
                category, type);
        }

        #endregion
    }
}
