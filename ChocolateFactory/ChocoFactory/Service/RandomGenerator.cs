using ChocoFactory.Domain;
using System;
using System.Linq;
using System.Threading;

namespace ChocoFactory.Services
{
    internal static class DataGenerator
    {
        private static Random rnd = new Random();

        public static decimal PricePerKilo(Quality quality)  //create a random Quality indicator 
        {
            Thread.Sleep(1);
            decimal number = rnd.Next(1, 3);
            return number * (int)quality;
        }

        public static Quality Quality()       //Create a random Object Quality
        {
            Thread.Sleep(1);
            Array values = Enum.GetValues(typeof(Quality));
            int index = rnd.Next(0, values.Length);
            return (Quality)values.GetValue(index);
        }

        public static int Quantity()       //create a random Quantity number with limitis 
        {
            Thread.Sleep(1);
            int num = rnd.Next(10000, 30001);
            return num;
        }

        public static int FakeID()             //Create a random ID number with limits [100-201]
        {
            Thread.Sleep(1);
            int x2 = rnd.Next(100, 200);
            return x2;
        }

        public static int FakeOrderID()        //Create a random OrderID number with limits [1000-2011]
        {
            Thread.Sleep(1);
            int x4 = rnd.Next(1000, 2011);
            return x4;
        }

        public static Factory RandomFactory(Company company)
        {
            Thread.Sleep(1);
            return company.Factories[rnd.Next(company.Factories.Count)];
        }
    }
}