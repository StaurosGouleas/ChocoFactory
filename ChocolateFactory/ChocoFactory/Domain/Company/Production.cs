using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChocoFactory.Services;

namespace ChocoFactory.Domain
{

    public class Production : IDepartment
    {
        //properties
        public Factory Factory { get; set; }
        public ProductionPolicy ProductionPolicy { get; set; } = new ProductionPolicy();

        public int DepartmentID { get; set; }

        public string Description { get; set; }

        public Production(Factory factory)
        {
            Factory = factory;
        }

        //methods
        public IProduct CreateProduct(string productName)
        {
            IProduct createdProduct = null;

            switch (productName)
            {
                case "BlackChocolate":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.BlackChocolateSupplies);
                    createdProduct = new BlackChocolate()
                    {
                        Description = "BlackChocolate",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(90),
                        Price = Factory.Company.CompanyPolicy.Pricing.BlackChocolatePrice
                    };
                    break;
                case "WhiteChocolate":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.WhiteChocolateSupplies);
                    createdProduct = new WhiteChocolate()
                    {
                        Description = "WhiteChocolate",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(60),
                        Price = Factory.Company.CompanyPolicy.Pricing.WhiteChocolatePrice
                    };
                    break;
                case "PlainMilkChocolate":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.MilkChocolateSupplies);
                    createdProduct = new PlainMilkChocolate()
                    {
                        Description = "PlainMilkChocolate",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(75),
                        Price = Factory.Company.CompanyPolicy.Pricing.MilkChocolatePrice
                    };
                    break;
                case "AlmondMilkChocolate":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.AlmondMilkChocolateSupplies);
                    createdProduct = new AlmondMilkChocolate()
                    {
                        Description = "AlmondMilkChocolate",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(75),
                        Price = Factory.Company.CompanyPolicy.Pricing.AlmondMilkChocolatePrice
                    };
                    break;
                case "HazelnutMilkChocolate":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.HazelnutMilkChocolateSupplies);
                    createdProduct = new HazelnutMilkChocolate()
                    {
                        Description = "HazelnutMilkChocolate",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(75),
                        Price = Factory.Company.CompanyPolicy.Pricing.HazelnutMilkChocolatePrice
                    };
                    break;
                case "ExperimentalProduct":
                    Factory.Warehouse.SendSupplies(ProductionPolicy.ExperimentalChocolateSupplies);
                    createdProduct = new ExperimentalProduct()
                    {
                        Description = "ExperimentalProduct",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(300),
                        Price = Factory.Company.CompanyPolicy.Pricing.ExperimentalChocolatePrice
            };

                    break;
                default:
                    Console.WriteLine("Error creating product");
                    break;
                   
               
            }
            return createdProduct;
            
        }

     



    }
}
