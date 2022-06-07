using ChocoFactory.Service;
using ChocoFactory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain
{


    public class Company : ICompany ,IActions

    {
        private readonly ISupplierService _supplierService;
        private readonly ICustomerService _customerService;
        public decimal Capital { get; private set; } = 1000000;
        public decimal Revenue { get; set; }
        public List<Factory> Factories { get; set; } = new List<Factory>();
        public List<Shop> Shops { get; set; } = new List<Shop>();
        public List<IEmployee> Employees { get; set; } = new List<IEmployee>();
        public CompanyPolicy CompanyPolicy { get; set; } = new CompanyPolicy();
        public bool RevenueGoalAchieved
        {
            get { return Revenue > (decimal)CompanyPolicy.Factory.RevenueYearlyGoal * Revenue; }
        }

        public Company(ISupplierService supplierService,ICustomerService customerService)
        {
            _supplierService = supplierService;
            _customerService = customerService;

            Factory factory = new Factory(this, supplierService);
            Factories.Add(factory);
            factory.OpeningActions();

            Shop shop = new Shop(this, factory, customerService);
            shop.RefillStock();
            Shops.Add(shop);
            factory.Shops.Add(shop);
        }

        public void OpeningActions()
        {
            Factories[0].OpeningActions();
            Shops[0].RefillStock();
        }
        

        public void DailyActions(DateTime currentDate)
        {
            Console.WriteLine($"Capital: {Capital}");
            Console.WriteLine($"Revenue: {Revenue}");

            foreach (Factory factory in Factories)
            {
                factory.DailyActions(currentDate);
            }

            foreach (Shop shop in Shops)
            {
                shop.DailyActions(currentDate);
            }
        }

        public void YearlyActions()
        {
            foreach (Factory factory in Factories)
            {
                factory.YearlyActions();
            }

            if (RevenueGoalAchieved)
            {
                Shop shop = new Shop(this, DataGenerator.RandomFactory(this), _customerService);
                shop.RefillStock();
                Shops.Add(shop);
                Console.WriteLine("NEW SHOP!!");
            }

            Console.WriteLine($"Number of Shops: {Shops.Count}");
            Capital += Revenue;
            Revenue = 0;
        }

        public void ReceiveMoney(decimal money)
        {
            Revenue += money;
        }

        public void PrintMockEmployeesData() 
        {
            var List = ImportJsonHelper.MockEmployeeList();
            foreach (var employee in List)
            {
                Console.WriteLine($"|ID: {employee.ID }|\t|Salary: {employee.Salary }|\t|DeparmentId: {employee.DeparmentId }" +
                    $"|\t|ManagerId: {employee.ManagerId }|\t|Firstname: {employee.Firstname }|\t" +
                    $"|Lastname: {employee.Lastname }|\t|Email: {employee.Email }|\t|Email: {employee.Phone }|");
            }
        }
    }
}
