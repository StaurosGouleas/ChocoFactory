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

    public class AccountingTests
    {
        [TestMethod()]
        public void ReceiveOffersTest()
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);    
            Factory factory = new Factory(company, serviceProvider);
            Accounting accounting = new Accounting(factory, serviceProvider);

            // Act
            accounting.ReceiveOffers();

            // Assert
            Assert.AreEqual(company.CompanyPolicy.Factory.NumberOfOffers, accounting.AvailableOffers.Count);
        }

        [TestMethod()]
        public void SendOrderTest()
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider)
            {
                Revenue = 100m
            };
            Factory factory = new Factory(company, serviceProvider);
            Accounting accounting = new Accounting(factory, serviceProvider);
            Warehouse warehouse = new Warehouse(factory)
            {
                SuppliesInKilo = 0
            };

            factory.Warehouse = warehouse;
            factory.Accounting = accounting;

            Offer offer = new Offer(1, Quality.Low, 100, new Supplier());

            // Act
            accounting.SendOrder(offer);

            // Assert
            Assert.AreEqual(warehouse.SuppliesInKilo, offer.Quantity);
            Assert.AreEqual(offer.TotalCost, 100);
            Assert.AreEqual(0, company.Revenue);
        }

        [TestMethod()]
        public void OfferValueTest()
        {
            // Arrange
            Offer offer1 = new Offer(10, Quality.Medium, 100, new Supplier());
            Offer offer2 = new Offer(10, Quality.Low, 100, new Supplier());

            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Accounting accounting = new Accounting(factory, serviceProvider);

            PrivateObject privateObject = new PrivateObject(accounting);

            Type[] typeArray = new Type[1] { typeof(Offer) };

            // Act
            var value1 = privateObject.Invoke("OfferValue", offer1);
            var value2 = privateObject.Invoke("OfferValue", offer2);

            // Assert
            Assert.IsTrue((double)value1 > (double)value2, "The offer2 had higher value than offer1.");
        }

        [TestMethod()]
        public void DiffPricePerKilo_SameQuality_BestOfferTest()
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Accounting accounting = new Accounting(factory, serviceProvider);

            Supplier supplier = new Supplier();

            Offer offer1 = new Offer(5, Quality.Medium, 100, supplier);
            Offer offer2 = new Offer(10, Quality.Medium, 100, supplier);
            Offer offer3 = new Offer(15, Quality.Medium, 100, supplier);

            // Act
            accounting.AvailableOffers = new List<Offer>()
            {
                offer1,
                offer2,
                offer3
            };

            // Assert
            Assert.AreEqual(offer1, accounting.BestOffer);
        }

        [TestMethod()]
        public void DiffQuality_SamePricePerKilo_BestOfferTest()
        {
            // Arrange
            ISupplierService serviceProvider = new SupplierService();
            ICustomerService customerProvider = new CustomerService();

            Company company = new Company(serviceProvider, customerProvider);
            Factory factory = new Factory(company, serviceProvider);
            Accounting accounting = new Accounting(factory, serviceProvider);

            Supplier supplier = new Supplier();

            Offer offer1 = new Offer(5, Quality.High, 100, supplier);
            Offer offer2 = new Offer(5, Quality.Medium, 100, supplier);
            Offer offer3 = new Offer(5, Quality.Low, 100, supplier);

            // Act
            accounting.AvailableOffers = new List<Offer>()
            {
                offer1,
                offer2,
                offer3
            };

            // Assert
            Assert.AreEqual(offer1, accounting.BestOffer);
        }

    }
}