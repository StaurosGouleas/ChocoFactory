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
    public class ShopTests
    {
        [TestMethod()]
        public void ResetDailyProductsSoldTests()
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Shop shop = new Shop(company, factory, customerProvider);

            foreach (var product in shop.DailyProductsSold.Keys.ToList<string>())
            {
                shop.DailyProductsSold[product]++;
            }

            PrivateObject privateObject = new PrivateObject(shop);

            // Act
            privateObject.Invoke("ResetDailyProductsSold");

            foreach (var product in shop.DailyProductsSold.Keys.ToList<string>())
            {
                Assert.AreEqual(0, shop.DailyProductsSold[product]);
            }
        }

        [TestMethod()]
        public void DiscountDay_IsDicountDayTest()
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Shop shop = new Shop(company, factory, customerProvider);

            DateTime notSecondTuesday = new DateTime(2022, 5, 10);

            PrivateObject privateObject = new PrivateObject(shop);

            // Act
            bool isDiscountDay = (bool)privateObject.Invoke("IsDiscountDay", notSecondTuesday);

            // Assert
            Assert.IsTrue(isDiscountDay);
        }

        [TestMethod()]
        public void NotDiscountDay_IsDicountDayTest()
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Shop shop = new Shop(company, factory, customerProvider);

            DateTime notSecondTuesday = new DateTime(2022, 5, 3);

            PrivateObject privateObject = new PrivateObject(shop);

            // Act
            bool isDiscountDay = (bool)privateObject.Invoke("IsDiscountDay", notSecondTuesday);

            // Assert
            Assert.IsFalse(isDiscountDay);
        }

        [DataTestMethod()]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void SellProductTest(string productName)
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Shop shop = new Shop(company, factory, customerProvider);

            var product = CreateTestProduct(productName);
            shop.Products.Add(product);

            PrivateObject privateObject = new PrivateObject(shop);

            // Act
            shop.SellProduct(productName);

            // Assert
            int counter = shop.DailyProductsSold[productName];
            Assert.AreEqual(1, counter);

            Assert.AreEqual(product.Price, shop.DailyEarnings);
            Assert.AreEqual(0, shop.Products.Count);
        }

        [TestMethod()]
        public void ServeCustomerTest()
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Shop shop = new Shop(company, factory, customerProvider);

            List<IProduct> products = new List<IProduct>
            {
                CreateTestProduct("WhiteChocolate"),
                CreateTestProduct("BlackChocolate"),
                CreateTestProduct("PlainMilkChocolate"),
                CreateTestProduct("AlmondMilkChocolate"),
                CreateTestProduct("HazelnutMilkChocolate"),
                CreateTestProduct("ExperimentalProduct")
            };

            shop.Products = products;
            shop.DailyProductsSold.Add("ExperimentalProduct", 1);

            List<string> productNames = new List<string>
            {
                 "WhiteChocolate" ,
                "BlackChocolate" ,
                "PlainMilkChocolate",
                "AlmondMilkChocolate",
                "HazelnutMilkChocolate",
            };
            decimal totalCost = 0;

            foreach (var product in shop.Products)
            {
                totalCost += product.Price;
            }

            // Act
            decimal customerCost = shop.ServeCustomer(productNames);

            // Assert
            Assert.AreEqual(totalCost, customerCost);
            Assert.AreEqual(1, shop.DailyProductsSold["ExperimentalProduct"]);
           
        }

        [TestMethod()]
        public void SendDailyEarningsTests()
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Shop shop = new Shop(company, factory, customerProvider)
            {
                DailyEarnings = 100
            };
            decimal revenueInit = company.Revenue;
            PrivateObject privateObject = new PrivateObject(shop);

            // Act
            privateObject.Invoke("SendDailyEarnings");

            // Assert
            Assert.AreEqual(revenueInit + 100, company.Revenue);
            Assert.AreEqual(0, shop.DailyEarnings);
        }

        [DataTestMethod()]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void NotLowQuantity_IsProductQuantityLowTests(string productName)
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Shop shop = new Shop(company, factory, customerProvider);

            company.CompanyPolicy.Shop.DailyProducts = 50;

            int stockProducts = 0;
            switch (productName)
            {
                case "BlackChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.BlackChocolatePercent);
                    break;
                case "WhiteChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.WhiteChocolatePercent);
                    break;
                case "PlainMilkChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.MilkChocolatePercent);
                    break;
                case "AlmondMilkChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.AlmondMilkChocolatePercent);
                    break;
                case "HazelnutMilkChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.HazelnutMilkChocolatePercent);
                    break;
                default:
                    break;
            }
            PrivateObject privateObject = new PrivateObject(shop);

            // Act
            for (int i = 0; i < stockProducts; i++)
            {
                shop.Products.Add(CreateTestProduct(productName));
            }

            // Assert
            Assert.IsFalse((bool)privateObject.Invoke("IsProductQuantityLow", productName), "The product quantity was low.");
        }

        [DataTestMethod()]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void LowQuantity_IsProductQuantityLowTests(string productName)
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Shop shop = new Shop(company, factory, customerProvider);

            company.CompanyPolicy.Shop.DailyProducts = 50;

            int stockProducts = 0;
            switch (productName)
            {
                case "BlackChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.BlackChocolatePercent);
                    break;
                case "WhiteChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.WhiteChocolatePercent);
                    break;
                case "PlainMilkChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.MilkChocolatePercent);
                    break;
                case "AlmondMilkChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.AlmondMilkChocolatePercent);
                    break;
                case "HazelnutMilkChocolate":
                    stockProducts = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.HazelnutMilkChocolatePercent);
                    break;
                default:
                    break;
            }
            PrivateObject privateObject = new PrivateObject(shop);

            for (int i = 0; i < stockProducts - 1; i++)
            {
                shop.Products.Add(CreateTestProduct(productName));
            }

            // Assert
            Assert.IsTrue((bool)privateObject.Invoke("IsProductQuantityLow", productName), "The product quantity was not low.");
        }

        [DataTestMethod()]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void RefillProductTests(string productName)
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Shop shop = new Shop(company, factory, customerProvider);

            int productMaxCapacity = 0;

            company.CompanyPolicy.Shop.DailyProducts = 50;

            switch (productName)
            {
                case "BlackChocolate":
                    productMaxCapacity = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.BlackChocolatePercent);
                    break;
                case "WhiteChocolate":
                    productMaxCapacity = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.WhiteChocolatePercent);
                    break;
                case "PlainMilkChocolate":
                    productMaxCapacity = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.MilkChocolatePercent);
                    break;
                case "AlmondMilkChocolate":
                    productMaxCapacity = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.AlmondMilkChocolatePercent);
                    break;
                case "HazelnutMilkChocolate":
                    productMaxCapacity = (int)Math.Floor(company.CompanyPolicy.Shop.ShopStockSize * company.CompanyPolicy.Production.HazelnutMilkChocolatePercent);
                    break;
                default:
                    break;
            }

            for (int i = 0; i < productMaxCapacity; i++)
            {
                factory.Warehouse.Products.Add(CreateTestProduct(productName));
            }

            PrivateObject privateObject = new PrivateObject(shop);

            // Act
            privateObject.Invoke("RefillProduct", productName);

            // Assert
            Assert.AreEqual(productMaxCapacity, shop.Products.Where(x => x.Description == productName).Count());
        }

        [DataTestMethod()]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void IfWarehouseHasProduct_ReceiveProductTest(string productName)
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            factory.Warehouse.Products.Add(CreateTestProduct(productName));
            Shop shop = new Shop(company, factory, customerProvider);

            PrivateObject privateObject = new PrivateObject(shop);

            // Act
            privateObject.Invoke("ReceiveProduct", productName);

            // Assert
            Assert.AreEqual(1, shop.Products.Count);
            Assert.AreEqual(productName, shop.Products[0].Description);
        }

        [DataTestMethod()]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void IfWarehouseHasNoProduct_DontReceiveProductTest(string productName)
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Shop shop = new Shop(company, factory, customerProvider);

            PrivateObject privateObject = new PrivateObject(shop);

            // Act
            privateObject.Invoke("ReceiveProduct", productName);

            // Assert
            Assert.AreEqual(0, shop.Products.Count);
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
            Shop shop = new Shop(company, factory, customerProvider);

            var product = CreateTestProduct(productName);
            shop.Products.Add(product);

            PrivateObject privateObject = new PrivateObject(shop);

            // Act
            privateObject.Invoke("ReceiveProduct", productName);
            privateObject.Invoke("RemoveExpiredProducts", yesterday);

            // Assert
            Assert.AreEqual(productName, shop.Products[0].Description);
        }

        [DataTestMethod()]
        [DataRow("WhiteChocolate")]
        [DataRow("BlackChocolate")]
        [DataRow("PlainMilkChocolate")]
        [DataRow("AlmondMilkChocolate")]
        [DataRow("HazelnutMilkChocolate")]
        public void RemoveExpiredProducts(string productName)
        {
            // Arrange
            DateTime today = DateTime.Today;
            DateTime farFuture = today.AddDays(10000);

            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Shop shop = new Shop(company, factory, customerProvider);

            var product = CreateTestProduct(productName);
            shop.Products.Add(product);

            PrivateObject privateObject = new PrivateObject(shop);

            // Act
            privateObject.Invoke("RemoveExpiredProducts", farFuture);

            int counter = shop.DailyProductsSold[productName];

            // Assert
            Assert.AreEqual(0, counter);
            Assert.AreEqual(0, shop.Products.Count);
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

