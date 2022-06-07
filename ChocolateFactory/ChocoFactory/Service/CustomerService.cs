using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChocoFactory.Domain;

namespace ChocoFactory.Services
{
    public class CustomerService : ICustomerService
    {
        Random rnd = new Random();
        private int maxProducts = 10;
        private int maxCustomers = 50;

        private string[] productNames = new string[]
        {
            "WhiteChocolate",
            "BlackChocolate",
            "PlainMilkChocolate",
            "AlmondMilkChocolate",
            "HazelnutMilkChocolate"
        };

        public void DailyPurchases(Shop shop)
        {
            int numberOfCustomers = rnd.Next(maxCustomers + 1);

            for (int i = 0; i < numberOfCustomers; i++)
            {
                List<string> products = ProductsToBuy();
                shop.ServeCustomer(products);
            }
        }
        private List<string> ProductsToBuy()
        {
            int randomNumberOfProducts = rnd.Next(1, maxProducts + 1);
            List<string> products = new List<string>();

            for (int i = 0; i < randomNumberOfProducts; i++)
            {
                string randomProduct = productNames[rnd.Next(productNames.Length)];
                products.Add(randomProduct);
            }

            return products;
        }


    }
}
