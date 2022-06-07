using ChocoFactory.Service;
using ChocoFactory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public class Shop 
    {
        //properties
        private readonly ICustomerService _customerService;

        public Company Company { get; set; }
        public Factory Factory { get; set; }
        public double Discount { get; set; } = 0;
        public List<IProduct> Products { get; set; } = new List<IProduct>();

        public List<Employee> Sellers { get; set; } = ImportJsonHelper.MockEmployeeList();

        public Dictionary<string, int> DailyProductsSold { get; set; } = new Dictionary<string, int>()
        {
            {"WhiteChocolate" , 0},
            {"BlackChocolate" , 0},
            {"PlainMilkChocolate" , 0},
            {"AlmondMilkChocolate" , 0},
            {"HazelnutMilkChocolate" , 0}
        };
        public string Location { get; set; }
        public decimal DailyEarnings { get; set; } = 0;

        public bool HasExperimentalProduct
        {
            get { return Products.Any(x => x.Description == "ExperimentalProduct"); }
        }


        // Constructor

        public Shop(Company company,Factory factory,ICustomerService customerService)
        {
            _customerService = customerService;
            Company = company;
            Factory = factory;

            Sellers = ImportJsonHelper.MockEmployeeList();
        }

        //methods
        public void DailyActions(DateTime currentDate)
        {
            Discount = IsDiscountDay(currentDate) ? Company.CompanyPolicy.Shop.ShopDiscount : 0;

            _customerService.DailyPurchases(this);

            SendDailyEarnings();

            ResetDailyProductsSold();

            RemoveExpiredProducts(currentDate);

            RefillStock();
        }

        private void ResetDailyProductsSold()
        {
            foreach (var productType in DailyProductsSold.Keys.ToList<string>())
            {
                DailyProductsSold[productType] = 0;
            }
        }

        private bool IsDiscountDay(DateTime currentDate)
        {
            if (!(currentDate.DayOfWeek == Company.CompanyPolicy.Shop.DiscountDay))
            {
                return false;
            }
            else
            {
                int weekInMonth = 0;
                DateTime dateTime = currentDate;
                
                do
                {
                    weekInMonth++;
                    dateTime = dateTime.AddDays(-7);

                } while (dateTime.Month == currentDate.Month);

                return weekInMonth == Company.CompanyPolicy.Shop.DiscountDayOccurence;
            }
        }

        public decimal SellProduct(string productName)
        {
            IProduct productToSell = Products.Find(x => x.Description == productName);

            decimal productPrice = 0;
            if (productToSell != null)
            {
                productPrice = productToSell.Price - productToSell.Price * (decimal)Discount;
                DailyEarnings += productPrice;
                Products.Remove(productToSell);
                DailyProductsSold[productName]++;
            }

            return productPrice;
        }

        public decimal ServeCustomer(List<string> productsToSell)
        {
            decimal totalCost = 0;
            foreach (string product in productsToSell)
            {
                try
                {
                        totalCost += SellProduct(product);
                }
                catch (NullReferenceException)
                {
                    //Console.WriteLine("The shop did not have the product.");
                }
            }

            if (HasExperimentalProduct && totalCost >= Company.CompanyPolicy.Shop.GiftMinimumPrice)
            {
                Products.Remove(Products.Find(x=>x.Description == "ExperimentalProduct"));
            }
            return totalCost;
        }

        private void DailyReport()
        {

            Console.WriteLine($"Our shop at {Location} made {DailyEarnings} Euro today.");
            Console.WriteLine("Products Sold:");
            foreach (var productType in DailyProductsSold)
            {
                Console.WriteLine($"\t{productType.Key}:{productType.Value}");
            }
        }

        private void SendDailyEarnings()
        {
            Company.ReceiveMoney(DailyEarnings);
            DailyEarnings = 0;
        }

        private bool IsProductQuantityLow(string productName)
        {
            int stockProducts = 0;
            switch (productName)
            {
                case "BlackChocolate":
                    stockProducts = (int)Math.Floor(Company.CompanyPolicy.Shop.ShopStockSize * Company.CompanyPolicy.Production.BlackChocolatePercent);
                    break;
                case "WhiteChocolate":
                    stockProducts = (int)Math.Floor(Company.CompanyPolicy.Shop.ShopStockSize * Company.CompanyPolicy.Production.WhiteChocolatePercent);
                    break;
                case "PlainMilkChocolate":
                    stockProducts = (int)Math.Floor(Company.CompanyPolicy.Shop.ShopStockSize * Company.CompanyPolicy.Production.MilkChocolatePercent);
                    break;
                case "AlmondMilkChocolate":
                    stockProducts = (int)Math.Floor(Company.CompanyPolicy.Shop.ShopStockSize * Company.CompanyPolicy.Production.AlmondMilkChocolatePercent);
                    break;
                case "HazelnutMilkChocolate":
                    stockProducts = (int)Math.Floor(Company.CompanyPolicy.Shop.ShopStockSize * Company.CompanyPolicy.Production.HazelnutMilkChocolatePercent);
                    break;
                default:
                    break;
            }
            int productCounter = Products.Where(x => x.Description == productName).Count();

            return productCounter < stockProducts;
        }

        private void RefillProduct(string productName)
        {
            int productMaxCapacity = 0;

            switch (productName)
            {
                case "BlackChocolate":
                    productMaxCapacity = (int)Math.Floor(Company.CompanyPolicy.Shop.ShopStockSize * Company.CompanyPolicy.Production.BlackChocolatePercent);
                    break;
                case "WhiteChocolate":
                    productMaxCapacity = (int)Math.Floor(Company.CompanyPolicy.Shop.ShopStockSize * Company.CompanyPolicy.Production.WhiteChocolatePercent);
                    break;
                case "PlainMilkChocolate":
                    productMaxCapacity = (int)Math.Floor(Company.CompanyPolicy.Shop.ShopStockSize * Company.CompanyPolicy.Production.MilkChocolatePercent);
                    break;
                case "AlmondMilkChocolate":
                    productMaxCapacity = (int)Math.Floor(Company.CompanyPolicy.Shop.ShopStockSize * Company.CompanyPolicy.Production.AlmondMilkChocolatePercent);
                    break;
                case "HazelnutMilkChocolate":
                    productMaxCapacity = (int)Math.Floor(Company.CompanyPolicy.Shop.ShopStockSize * Company.CompanyPolicy.Production.HazelnutMilkChocolatePercent);
                    break;
                default:
                    break;
            }

            int productsInStock = Products.Count(x => x.Description == productName);
            while (productsInStock < productMaxCapacity)
            {
                ReceiveProduct(productName);
                productsInStock++;
            }      
        }

        public void RefillStock()
        {
            foreach (string productName in DailyProductsSold.Keys.ToList<string>())
            {
                if (IsProductQuantityLow(productName))
                {
                    RefillProduct(productName);
                }
            }
        }

        private void ReceiveProduct(string productName)
        {
            IProduct newProduct = Factory.Warehouse.SendProduct(productName);
            if (newProduct != null)
                Products.Add(newProduct);          
        }

        private void RemoveExpiredProducts(DateTime currentDate)
        {
            IProduct product;
            for (int i = 0; i < Products.Count; i++)
            {
                product = Products[i];

                if (product is IChocolate chocolate)
                {
                    if (DateTime.Compare(chocolate.ExpirationDate, currentDate) < 0)
                    {
                        Products.Remove(product);
                    }
                }
            }

           
        }


    }
}
