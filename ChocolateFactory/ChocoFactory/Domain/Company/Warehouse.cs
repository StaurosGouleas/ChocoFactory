using ChocoFactory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{
    public class Warehouse : IDepartment
    {

        //properties
        public Factory Factory { get; set; }
        public List<IProduct> Products { get; set; } = new List<IProduct>();
        public Dictionary<string, int> ProductQuantity { get; set; } = new Dictionary<string, int>()
        {
            {"WhiteChocolate" , 0},
            {"BlackChocolate" , 0},
            {"PlainMilkChocolate" , 0},
            {"AlmondMilkChocolate" , 0},
            {"HazelnutMilkChocolate" , 0}
        };
        public int SuppliesInKilo { get; set; }
        public int ExperimentalSupplies { get; set; }
        public bool AreSuppliesLow
        {
            get
            {
                return SuppliesInKilo <= Factory.Accounting.LastOrder.Quantity * Factory.Company.CompanyPolicy.Factory.LowSuppliesThresholdPercent;
            }
        }

        public int DepartmentID { get; set; }

        public string Description { get; set; }

        //constructor
        public Warehouse(Factory factory)
        {
            Factory = factory;
        }


        //methods

        public void DailyActions(DateTime currentDate)
        {
            Console.WriteLine($"Supplies today: {SuppliesInKilo}");
            RemoveExpiredProducts(currentDate);
            GetDailyProducts();

            if (AreSuppliesLow)
            {
                Factory.Accounting.SendOrder(Factory.Accounting.LastOrder);
            }
        }

        public void GetSupplies(int supplies)
        {
            SuppliesInKilo += supplies;
        }

        public void SendSupplies(int kilos)//called from Production
        {
            SuppliesInKilo -= kilos;          
        }

        public void GetProduct(string productName)
        {
            IProduct newProduct = Factory.Production.CreateProduct(productName);
            Products.Add(newProduct);
            ProductQuantity[productName]++;
        }

        public IProduct SendProduct(string productName)
        {
            IProduct productToSend = Products.Find(x => x.Description == productName);
            Products.Remove(productToSend);
            ProductQuantity[productName]--;
            return productToSend;
        }

        private void RemoveExpiredProducts(DateTime currentDate)
        {
            IChocolate product;//ExpireDateTime included for now only for chocolate products

            for (int i = 0; i < Products.Count; i++)
            {
                product = (IChocolate)Products[i];
                if (DateTime.Compare(product.ExpirationDate, currentDate) < 0)
                {
                    ProductQuantity[product.Description]--;
                    Products.Remove(product);
                }
            }
        }

        public void RefillProduct(string productName, double policyPercentage)
        {
            int numberOfProductDaily = (int)Math.Floor(policyPercentage * Factory.Company.CompanyPolicy.Factory.DailyProducts);

            for (int i = 1; i <= numberOfProductDaily; i++)
            {
                GetProduct(productName);              
            }
        }

        public void GetDailyProducts()
        {
            foreach (string productName in ProductQuantity.Keys.ToList<string>())
            {
                double dailyProduction;

                switch (productName)
                {
                    case "BlackChocolate":
                        dailyProduction = Factory.Company.CompanyPolicy.Production.BlackChocolatePercent;
                        RefillProduct(productName, dailyProduction);
                        break;
                    case "WhiteChocolate":
                        dailyProduction = Factory.Company.CompanyPolicy.Production.WhiteChocolatePercent;
                        RefillProduct(productName, dailyProduction);
                        break;
                    case "PlainMilkChocolate":
                        dailyProduction = Factory.Company.CompanyPolicy.Production.MilkChocolatePercent;
                        RefillProduct(productName, dailyProduction);
                        break;
                    case "AlmondMilkChocolate":
                        dailyProduction = Factory.Company.CompanyPolicy.Production.AlmondMilkChocolatePercent;
                        RefillProduct(productName, dailyProduction);
                        break;
                    case "HazelnutMilkChocolate":
                        dailyProduction = Factory.Company.CompanyPolicy.Production.HazelnutMilkChocolatePercent;
                        RefillProduct(productName, dailyProduction);
                        break;
                    case "ExperimentalProduct":
                        dailyProduction = Factory.Company.CompanyPolicy.Production.ExperimentalPercent;
                        RefillProduct(productName, dailyProduction);
                        break;
                    default:
                        break;
                }
            }
        }

        public void AddExperimentalProduct()
        {
            if (SuppliesInKilo > 0)
            {
                ExperimentalSupplies += SuppliesInKilo;
                SuppliesInKilo = 0;
                try
                {
                    ProductQuantity.Add("ExperimentalProduct", 0);

                }
                catch (Exception)
                {
                    Console.WriteLine($"Factory already has Experimental Products.");
                }
            }
        }



    }
}
