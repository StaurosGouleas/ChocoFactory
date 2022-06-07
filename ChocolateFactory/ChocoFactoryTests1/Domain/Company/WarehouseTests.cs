using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChocoFactory.Domain;
using ChocoFactory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain.Tests
{
    [TestClass()]
    public class WarehouseTests
    {
        [TestMethod()]
        public void GetSuppliesTest()
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory)
            {
                SuppliesInKilo = 0
            };

            int supplies = 100;

            // Act
            warehouse.GetSupplies(supplies);

            // Assert
            Assert.AreEqual(supplies, warehouse.SuppliesInKilo);
        }

        [TestMethod()]
        public void SendSuppliesTest()
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory)
            {
                SuppliesInKilo = 100
            };

            int supplies = 100;

            // Act
            warehouse.SendSupplies(supplies);

            // Assert
            Assert.AreEqual(0, warehouse.SuppliesInKilo);
        }

        [DataTestMethod]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void GetProductTest(string productName)
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory);

            // Act
            warehouse.GetProduct(productName);

            // Assert
            int counter = warehouse.ProductQuantity[productName];

            Assert.AreEqual(1, counter);
            Assert.AreEqual(1, warehouse.Products.Count);
            Assert.AreEqual(productName, warehouse.Products[0].Description);
        }

        [DataTestMethod]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void SendProductTest(string productName)
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory);

            var product = CreateTestProduct(productName);
            warehouse.Products.Add(product);
            warehouse.ProductQuantity[productName]++;

            // Act
            var productToSend = warehouse.SendProduct(productName);

            // Assert
            int counter = warehouse.ProductQuantity[productName];

            Assert.AreEqual(0, counter);
            Assert.AreEqual(0, warehouse.Products.Count);
            Assert.AreEqual(product, productToSend);
        }

        [DataTestMethod]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void DontRemove_NotExpiredProductsTest(string productName)
        {
            // Arrange
            DateTime today = DateTime.Today;
            DateTime yesterday = today.AddDays(-1);

            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory);
            var product = CreateTestProduct(productName);
            warehouse.Products.Add(product);
            warehouse.ProductQuantity[productName]++;

            PrivateObject privateObject = new PrivateObject(warehouse);

            // Act
            privateObject.Invoke("RemoveExpiredProducts", yesterday);

            // Assert
            int counter = warehouse.ProductQuantity[productName];

            Assert.AreEqual(1, counter);
            Assert.AreEqual(productName, warehouse.Products[0].Description);
        }

        [DataTestMethod]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void RemoveExpiredProductsTest(string productName)
        {
            // Arrange
            DateTime today = DateTime.Today;
            DateTime farFuture = today.AddDays(10000);

            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory);
            var product = CreateTestProduct(productName);
            warehouse.Products.Add(product);
            warehouse.ProductQuantity[productName]++;

            PrivateObject privateObject = new PrivateObject(warehouse);

            // Act
            privateObject.Invoke("RemoveExpiredProducts", farFuture);

            // Assert
            int counter = warehouse.ProductQuantity[productName];

            Assert.AreEqual(0, counter);
            Assert.AreEqual(0, warehouse.Products.Count);
        }

        [DataTestMethod]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void RefillProductTest(string productName)
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory);

            // Act
            warehouse.RefillProduct(productName, 1);

            // Assert
            int dailyProducts = company.CompanyPolicy.Factory.DailyProducts;
            int counter = warehouse.ProductQuantity[productName];

            Assert.AreEqual(dailyProducts, counter);
        }


        [DataTestMethod]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void GetDailyProductsTest(string productName)
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory);

            // Act
            warehouse.GetDailyProducts();

            // Assert
            int products = 0;

            switch (productName)
            {
                case "BlackChocolate":
                    products = (int)Math.Floor(company.CompanyPolicy.Factory.DailyProducts * company.CompanyPolicy.Production.BlackChocolatePercent);

                    break;
                case "WhiteChocolate":
                    products = (int)Math.Floor(company.CompanyPolicy.Factory.DailyProducts * company.CompanyPolicy.Production.WhiteChocolatePercent);

                    break;
                case "PlainMilkChocolate":
                    products = (int)Math.Floor(company.CompanyPolicy.Factory.DailyProducts * company.CompanyPolicy.Production.MilkChocolatePercent);

                    break;
                case "AlmondMilkChocolate":
                    products = (int)Math.Floor(company.CompanyPolicy.Factory.DailyProducts * company.CompanyPolicy.Production.AlmondMilkChocolatePercent);
                    break;
                case "HazelnutMilkChocolate":
                    products = (int)Math.Floor(company.CompanyPolicy.Factory.DailyProducts * company.CompanyPolicy.Production.HazelnutMilkChocolatePercent);
                    break;
                case "ExperimentalProduct":
                    products = (int)Math.Floor(company.CompanyPolicy.Factory.DailyProducts * company.CompanyPolicy.Production.ExperimentalPercent);
                    break;
                default:
                    break;

            }

            Assert.AreEqual(products, warehouse.ProductQuantity[productName]);
        }

        [TestMethod()]
        public void DontAddExperimentalProductTest()
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory)
            {
                SuppliesInKilo = 0
            };
            string productName = "ExperimentalProduct";

            // Act
            warehouse.AddExperimentalProduct();

            // Assert
            Assert.IsFalse(warehouse.ProductQuantity.ContainsKey(productName), "The Dictionary contains experimental products");
        }

        [TestMethod()]
        public void AddExperimentalProductTest()
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Warehouse warehouse = new Warehouse(factory)
            {
                SuppliesInKilo = 100
            };
            string productName = "ExperimentalProduct";

            // Act
            warehouse.AddExperimentalProduct();

            // Assert
            Assert.IsTrue(warehouse.ProductQuantity.ContainsKey(productName), "The Dictionary does not contain experimental products");

            // Can I call other test methods to verify that they work with experimental products?
        }

        public IProduct CreateTestProduct(string productName)
        {
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);

            IProduct createdProduct = null;

            switch (productName)
            {
                case "BlackChocolate":
                    createdProduct = new BlackChocolate()
                    {
                        Description = "BlackChocolate",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(90),
                        Price = factory.Company.CompanyPolicy.Pricing.BlackChocolatePrice
                    };
                    break;
                case "WhiteChocolate":
                    createdProduct = new WhiteChocolate()
                    {
                        Description = "WhiteChocolate",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(60),
                        Price = factory.Company.CompanyPolicy.Pricing.WhiteChocolatePrice
                    };
                    break;
                case "PlainMilkChocolate":
                    createdProduct = new PlainMilkChocolate()
                    {
                        Description = "PlainMilkChocolate",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(75),
                        Price = factory.Company.CompanyPolicy.Pricing.MilkChocolatePrice
                    };
                    break;
                case "AlmondMilkChocolate":
                    createdProduct = new AlmondMilkChocolate()
                    {
                        Description = "AlmondMilkChocolate",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(75),
                        Price = factory.Company.CompanyPolicy.Pricing.AlmondMilkChocolatePrice
                    };
                    break;
                case "HazelnutMilkChocolate":
                    createdProduct = new HazelnutMilkChocolate()
                    {
                        Description = "HazelnutMilkChocolate",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(75),
                        Price = factory.Company.CompanyPolicy.Pricing.HazelnutMilkChocolatePrice
                    };
                    break;
                case "ExperimentalProduct":
                    createdProduct = new ExperimentalProduct()
                    {
                        Description = "ExperimentalProduct",
                        ProductionDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(300),
                        Price = factory.Company.CompanyPolicy.Pricing.ExperimentalChocolatePrice
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