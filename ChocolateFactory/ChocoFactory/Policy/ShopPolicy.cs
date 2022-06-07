using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Policy
{
    public class ShopPolicy
    {
        // properties
        public int DailyProducts { get; set; }
        public double ProductsToShopPercent { get; private set; } 
        public double ShopRestockPercent { get; private set; } 
        public int ShopStockSize
        {
            get { return (int)Math.Floor(DailyProducts * ProductsToShopPercent); }
        }
        public int ShopRestockThreshold
        {
            get { return (int)Math.Floor(DailyProducts * ProductsToShopPercent * ShopRestockPercent); }
        }
        public double ShopDiscount { get; private set; } 
        public DayOfWeek DiscountDay { get; private set; } 
        public int DiscountDayOccurence { get; private set; } 
        public decimal GiftMinimumPrice { get; private set; } 


        //constuctor
        public ShopPolicy(int dailyProducts)
        {
            DailyProducts = dailyProducts;
            ProductsToShopPercent = 0.50;
            ShopRestockPercent = 0.25;
            ShopDiscount = 0.20;
            DiscountDay = DayOfWeek.Tuesday;
            DiscountDayOccurence = 2; // Every second Tuesday of each month.
            GiftMinimumPrice = 30;
        }
    }
}
