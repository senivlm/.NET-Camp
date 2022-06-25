using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    static class MenuService
    {
        public static bool TryGetGeneralPrice(Menu menu, PriceList priceList, out double menuTotalPrice)
        {
            menuTotalPrice = 0;
            for (int i = 0; i < menu.Length; i++)
            {
                if(!TryGetDishPrice(menu[i], priceList, out double sumPrice))
                {
                    return false;
                }
                menuTotalPrice += sumPrice;
            }
            return true;
        }

        public static bool TryGetDishPrice(Dish dish, PriceList priceList, out double sumPrice)
        {
            sumPrice = 0;
            foreach (string key in dish.Keys)
            {
                if (!priceList.TryGetProductPrice(key, out double productPrice))
                {
                    return false;
                }
                sumPrice += productPrice / 1000 * dish[key];
            }
            return true;
        }

        public static Dictionary<string, double> GetEachProductGeneralGrams(Menu menu, PriceList priceList)
        {
            Dictionary<string, double> result = priceList.ProductPrice.ToDictionary(entry => entry.Key, entry => 0.0);
            for (int i = 0; i < result.Count; i++)
            {
                foreach (var dish in menu.Dishes)
                {
                    foreach (KeyValuePair<string, double> items in dish.Ingredients)
                    {
                        if (result.ElementAt(i).Key == items.Key)
                        {
                            result[result.ElementAt(i).Key] += items.Value;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public static Dictionary<string, double> GetEachProductPrice(Dictionary<string, double> gramsOfEachProduct, PriceList priceList, double rate)
        {
            Dictionary<string, double> priceEachProduct = new();
            foreach (var item in gramsOfEachProduct)
            {
                priceEachProduct.Add(item.Key, item.Value * priceList.ProductPrice[item.Key] / 1000.0 / rate);
            }
            return priceEachProduct;
        }
    }
}
